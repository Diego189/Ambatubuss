using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    // Update is called once per frame
    void Update()
    {
        SetLookDirection();
    }

    /// <summary>
    /// This code adjusts the "up" direction of an object in 3D space to point towards a target object by calculating the vector between the two positions
    ///  This script is assigned to the game object that should be facing towards the target in the Unity Engine 
    /// </summary>
   
    void SetLookDirection()
    {
        transform.up = target.position - transform.position; 
    }
}
