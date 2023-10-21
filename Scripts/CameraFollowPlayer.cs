using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f); // This is here so the camera isn't on the EXACT player position
    private Vector3 velocity = Vector3.zero; // We need an empty vector3 to use in SmoothDamp
    [SerializeField] GameObject thingToFollow; // This will be the player, it can be interacted with in the script component in Unity 
    [SerializeField] float delay = 0.125f; // The delay of the camera while following player



    void LateUpdate() // Late update is better for smooth camera movement
    {
        Vector3 desiredPosition = thingToFollow.transform.position + offset; // This is the desired position for our camera
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, delay); // This is making the camera's position equal to the desired position. 
        // SmoothDamp is simply changing the camera's Vector3 to the desired Vector3 over time/delay.
    }
}
