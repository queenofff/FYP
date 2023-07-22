using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingobjectpush : MonoBehaviour
{
    [SerializeField] private float gridSize = 1f;
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 normal = other.contacts[0].normal;
            float dotProduct = Vector2.Dot(normal, Vector2.right);
            
            if (dotProduct > 0)
            {
                Debug.Log("Collided from the right!");
            }
            else if (dotProduct < 0)
            {
                Debug.Log("Collided from the left!");
            }
        } 
        
    }
}
