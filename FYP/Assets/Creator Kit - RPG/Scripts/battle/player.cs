using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private GameObject[] Box;

    [SerializeField] private GameObject[] Wall;
    [SerializeField] private GameObject[] goal;
    [SerializeField] private bool ReadyToMove;
    void Start()
    {
        Box = GameObject.FindGameObjectsWithTag("box");
        Wall = GameObject.FindGameObjectsWithTag("wall");
        goal = GameObject.FindGameObjectsWithTag("goal");
    }
    
    void Update()
    {
        Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveinput.Normalize();
        if (moveinput.sqrMagnitude >0.5)
        {
            if (ReadyToMove)
            {
                ReadyToMove = false;
                Move(moveinput);
            }
        }
        else
        {
            ReadyToMove = true;
        }
    }

    public bool Move(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();
    
        if (Blocked(transform.position,direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    public bool Blocked(Vector3 postion, Vector2 direction)
    {
        Vector2 newpos = new Vector2(postion.x, postion.y) + direction;

        foreach (var wall in Wall)
        {
            if (wall.transform.position.x == newpos.x && wall.transform.position.y == newpos.y)
            {
                return true;
            }
        }

        foreach (var box in Box)
        {
            if (box.transform.position.x == newpos.x && box.transform.position.y == newpos.y)
            {
                if (!box.activeSelf)
                {
                    return false;
                }
                Push objpush = box.GetComponent<Push>();
                if (objpush && objpush.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        foreach (var goalpoint in goal)
        {
            if (goalpoint.transform.position.x == newpos.x && goalpoint.transform.position.y == newpos.y)
            {
                Debug.Log("Win");
            }
        }

        
        return false;
    }
    
}
