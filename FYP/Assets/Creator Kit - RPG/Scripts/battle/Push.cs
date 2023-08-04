using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField] private GameObject[] Box;

    [SerializeField] private GameObject[] Wall;

    [SerializeField] private int HP = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        Box = GameObject.FindGameObjectsWithTag("box");
        Wall = GameObject.FindGameObjectsWithTag("wall");
    }
    
    public bool Move(Vector2 direction)
    {
        if (objBlocked(transform.position,direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    public bool objBlocked(Vector3 postion, Vector2 direction)
    {
        Vector2 newpos = new Vector2(postion.x, postion.y) + direction;

        foreach (var wall in Wall)
        {
            if (wall.transform.position.x == newpos.x && wall.transform.position.y == newpos.y)
            {
                HP -= 1;
                if (HP == 0)
                {
                    gameObject.SetActive(false);
                }
                return true;
            }
        }

        foreach (var box in Box)
        {
            if (box.transform.position.x == newpos.x && box.transform.position.y == newpos.y)
            {
                return true;
            }
        }
        return false;
    }
    
    

}
