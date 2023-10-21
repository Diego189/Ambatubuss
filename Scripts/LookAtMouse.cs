using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] PlayerFOV playerFOV;
    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody2D rb;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        GetMousePos(); // Gets mouse position
    }

    void FixedUpdate()
    {
        FaceMouse(); // Makes the player face the mouse
    }

    void FaceMouse()
    {
        Vector2 lookDir = mousePos - rb.position; // This gives us a vector that points from the player to the camera. When two Vectors are subtracted...
                                                  // You get one vector that points from one to the other
        playerFOV.SetAimDirection(lookDir); // This gives the angle between the player and mouse to playerFOV
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; // This is the z rotation of the player. Atan2 is a math Function that returns the angle between the vector...
                                                                         // and the x axis
        rb.rotation = angle; // Setting player rotation to the one we worked out above
    }

    void GetMousePos()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); // This gets the position of the mouse in World Units
                                                                // Input.mousePosition returns the position of the mouse in pixel coordinates, which can't be used. We need World Units         
    }
}
