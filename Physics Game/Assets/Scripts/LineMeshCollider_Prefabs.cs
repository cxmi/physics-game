using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class LineMeshCollider_Prefabs : MonoBehaviour
{
    public LineRenderer lineRenderer;  // The LineRenderer component
    public GameObject cubePrefab;     // Prefab for the cube to instantiate
    public float cubeWidth = 1f;      // Width of the cube (same as collider width)
    public float cubeHeight = 1f;     // Height of the cube (same as collider height)
    public float cubeDepth = 1f;      // Depth of the cube (same as collider depth)

    private GameObject[] cubeObjects; // Array to store the instantiated cubes
    private int prevPointCount = 0;    // Track previous point count



    void Start()
    {
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer is not assigned.");
            return;
        }

        // Initialize the cube array with the initial number of points
        prevPointCount = lineRenderer.positionCount;
        cubeObjects = new GameObject[prevPointCount - 1];

        // Create initial cubes for the first set of points
        CreateCubesAlongLine();
    }

    void Update()
    {
        // Check if the number of points has changed in the LineRenderer
        int pointCount = lineRenderer.positionCount;

        if (pointCount != prevPointCount)
        {
            // Adjust the cube array size if the number of points has changed
            System.Array.Resize(ref cubeObjects, pointCount - 1);
            prevPointCount = pointCount;

            // Recreate cubes based on updated points
            CreateCubesAlongLine();
        }

        // Continuously update the cubes to match the updated line positions
        UpdateCubes();
    }

    void CreateCubesAlongLine()
    {
        // Loop through each pair of points to create cubes between them
        for (int i = 0; i < lineRenderer.positionCount - 1; i++)
        {
            Vector3 startPoint = lineRenderer.GetPosition(i);
            Vector3 endPoint = lineRenderer.GetPosition(i + 1);

            // If a cube doesn't exist at this index, create it
            if (cubeObjects[i] == null)
            {
                cubeObjects[i] = CreateCube(startPoint, endPoint);
            }
        }
    }

    void UpdateCubes()
    {
        // Loop through the existing cubes and update their positions and sizes
        for (int i = 0; i < cubeObjects.Length; i++)
        {
            Vector3 startPoint = lineRenderer.GetPosition(i);
            Vector3 endPoint = lineRenderer.GetPosition(i + 1);

            // Update the position of the cube to the midpoint of the line segment
            cubeObjects[i].transform.position = (startPoint + endPoint) / 2;

            // Update the scale of the cube to match the distance between points
            Vector3 direction = endPoint - startPoint;
            float distance = direction.magnitude;

            // Update the cube's scale to match the line segment distance
            cubeObjects[i].transform.localScale = new Vector3(cubeWidth, cubeHeight, Math.Max(0, distance-1));

            // Optionally, update the cube's rotation to match the line segment direction
            cubeObjects[i].transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    GameObject CreateCube(Vector3 startPoint, Vector3 endPoint)
    {
        // Calculate the direction between the start and end points
        Vector3 direction = endPoint - startPoint;

        // Calculate the distance between the start and end points
        float distance = direction.magnitude;

        // Calculate the midpoint between the two points
        Vector3 midpoint = (startPoint + endPoint) / 2;

        // Instantiate a cube GameObject (use a prefab or built-in cube)
        GameObject cube = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        // Position the cube at the midpoint
        cube.transform.position = midpoint;

        // Rotate the cube to align with the direction of the line segment
        cube.transform.rotation = Quaternion.LookRotation(direction);

        // Add a BoxCollider component to the cube
        BoxCollider boxCollider = cube.AddComponent<BoxCollider>();

        // Set the size of the BoxCollider (it will be automatically adjusted by the cube scale)
        boxCollider.size = new Vector3(cubeWidth, cubeHeight, distance);

        return cube;
    }

}
