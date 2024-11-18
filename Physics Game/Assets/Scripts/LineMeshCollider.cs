using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineMeshCollider : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject colliderPrefab;  // Optional: A prefab to use for visualizing the colliders
    public float colliderWidth = 1f;   // Width of the box colliders
    public float colliderHeight = 1f;  // Height of the box colliders

    private BoxCollider[] boxColliders; // Array to store the colliders
    private int prevPointCount = 0;     // Track previous point count
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the collider array with the initial number of points
        prevPointCount = lineRenderer.positionCount;
        boxColliders = new BoxCollider[prevPointCount - 1];

        // Create initial colliders for the first set of points
        CreateCollidersAlongLine();        
    }

    // Update is called once per frame
    void Update()
    {
 // Check if the number of points has changed in the LineRenderer
        int pointCount = lineRenderer.positionCount;

        if (pointCount != prevPointCount)
        {
            // Adjust the BoxCollider array size if the number of points has changed
            System.Array.Resize(ref boxColliders, pointCount - 1);
            prevPointCount = pointCount;

            // Recreate colliders based on updated points
            CreateCollidersAlongLine();
        }

        // Continuously update the colliders to match the updated line positions
        UpdateColliders();
    }void CreateCollidersAlongLine()
    {
        // Loop through each pair of points to create colliders between them
        for (int i = 0; i < lineRenderer.positionCount - 1; i++)
        {
            Vector3 startPoint = lineRenderer.GetPosition(i);
            Vector3 endPoint = lineRenderer.GetPosition(i + 1);

            // If a collider doesn't exist at this index, create it
            if (boxColliders[i] == null)
            {
                boxColliders[i] = CreateBoxCollider(startPoint, endPoint);
            }
        }
    }

    void UpdateColliders()
    {
        // Loop through the existing colliders and update their positions and sizes
        for (int i = 0; i < boxColliders.Length; i++)
        {
            Vector3 startPoint = lineRenderer.GetPosition(i);
            Vector3 endPoint = lineRenderer.GetPosition(i + 1);

            // Update the position of the collider to the midpoint of the line segment
            boxColliders[i].transform.position = (startPoint + endPoint) / 2;

            // Update the size of the collider to match the distance between points
            Vector3 direction = endPoint - startPoint;
            float distance = direction.magnitude; 
           boxColliders[i].size = new Vector3(colliderWidth, colliderHeight, Math.Max(0, distance-1) );
            //unsure if max max or math clamp? Math.Max(0, distance-1)

           //SOMETHING WRONG WITH THE Z AXIS OF THE BOX COLLIDER

            // Optionally, update the collider's rotation to match the line segment direction
            boxColliders[i].transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    BoxCollider CreateBoxCollider(Vector3 startPoint, Vector3 endPoint)
    {
        // Calculate the direction between the start and end points
        Vector3 direction = endPoint - startPoint;

        // Calculate the distance between the start and end points
        float distance = direction.magnitude;

        // Calculate the midpoint between the two points
        Vector3 midpoint = (startPoint + endPoint) / 2;

        // Create a new GameObject for the BoxCollider
        GameObject colliderObject = new GameObject("BoxCollider");

        // Position the collider at the midpoint
        colliderObject.transform.position = midpoint;

        // Rotate the collider to align with the direction of the line segment
        colliderObject.transform.rotation = Quaternion.LookRotation(direction);

        // Add a BoxCollider component to the GameObject
        BoxCollider boxCollider = colliderObject.AddComponent<BoxCollider>();

        // Set the size of the BoxCollider
        boxCollider.size = new Vector3(colliderWidth, colliderHeight, distance);

        // Optionally, make this collider a trigger (if you don't want it to block physics)
        //boxCollider.isTrigger = true;

        return boxCollider;
    }
}
