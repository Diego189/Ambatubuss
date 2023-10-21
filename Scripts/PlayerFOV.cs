using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerFOV : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask; // This is used to determine what the FOV should not go through.
    [SerializeField] private float fov; // This is the magnitude of the FOV
    [SerializeField] private float viewDistance; // The linear distance the player can see 
    [SerializeField] private int rayCount; // This variable controls the smoothness of the fov
    private Vector3 origin; // The origin of the FOV
    private Mesh mesh;
    private float startingAngle; // This is the starting angle of the FOV
    void Start()
    {
        // Setting values to be used in the HandleFieldOfView
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
    }

    void LateUpdate()
    {
        HandleFieldOfView(); // This function basically creates two isoceles triangles that create the shape of a field of view
    }


    void HandleFieldOfView()
    {
        float angle = startingAngle; // The starting angle the Mesh should take
        float angleIncrease = fov / rayCount; // This determines each subsequent increment of each ray

        // Variables used for storing these mesh values
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin; // Sets the start of the mesh/Fov to the wanted position

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++) // This loop casts rays and generates vertices for the mesh.
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, layerMask); // Allows use of collision detection

            if (raycastHit2D.collider == null) // If collision is not detected
            {
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance; // Allows FoV to reach max distance  
            }
            else // If collision is detected
            {
                vertex = raycastHit2D.point; // Sets FoV to the point at which it collided
            }

            vertices[vertexIndex] = vertex; // The newly calculated vertex is stored in the vertices array at the current vertexIndex.

            if (i > 0) // If loop has iterated more than once
            {
                // triangles are formed by specifying the indices of the vertices in the triangles array.
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++; // Incremented for next iteration
            angle -= angleIncrease; // decremented by angleIncrease to calculate the next ray's direction
        }
        // Applying all calculations to the mesh
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = UtilsClass.GetAngleFromVectorFloat(aimDirection) + fov / 2f; // This makes the starting angle of the field of view face the same way as the player
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin; // Sets the origin of the field of view the same as the player's
    }
    
}

