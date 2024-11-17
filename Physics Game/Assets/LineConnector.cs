using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    //public GameObject lineObjectRef;
    public GameObject sphereHead;
    public GameObject sphere1;
    public GameObject sphere2;
    public GameObject sphereButt;
    //private LineRenderer lineRenderer;


     public Vector3[] positions;
    // Start is called before the first frame update
    void Start()
    {
        // Get the LineRenderer component attached to this GameObject
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        // Set the number of points in the LineRenderer based on the length of the positions array
        lineRenderer.positionCount = positions.Length;

 

        // // Set each point's position
        // for (int i = 0; i < positions.Length; i++)
        // {
        //     lineRenderer.SetPosition(i, positions[i]);
        // }

        
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        Vector3 positionAtHead = sphereHead.transform.position;
        Vector3 positionAtIndex1 = sphere1.transform.position;
        Vector3 positionAtIndex2 = sphere2.transform.position;
        Vector3 positionAtIndex3 = sphereButt.transform.position;
        //DEBUG ATTEMPT
        //lineRenderer.SetPosition(0, new Vector3(10, 10, 10)); 

        for (int i = 0; i < positions.Length; i++)
        {

            switch (i)
            {
                case 0:
                    positions[i] = positionAtHead + new Vector3(0,1,0);
                    break;
                case 1:
                    positions[i] = positionAtIndex1 + new Vector3(0,1,0);
                    break;
                case 2:
                    positions[i] = positionAtIndex2 + new Vector3(0,1,0);  // Example for index 2
                    break;
                case 3:
                    positions[i] = positionAtIndex3+ new Vector3(0,1,0);  // Example for index 3
                    break;
            }

            // Set the position in the LineRenderer for each index
            lineRenderer.SetPosition(i, positions[i]);

         }


        // LineRenderer lineRenderer = GetComponent<LineRenderer>();
        // Vector3 positionAtIndex0 = lineRenderer.GetPosition(0);
        // Vector3 positionAtIndex1 = lineRenderer.GetPosition(1);
        // Vector3 positionAtIndex2 = lineRenderer.GetPosition(2);
        // Vector3 positionAtIndex3 = lineRenderer.GetPosition(3);

        // Vector3 positionHead = sphereHead.transform.position; 
        // Vector3 position1 = sphere1.transform.position;
        // Vector3 position2 = sphere2.transform.position;
        // Vector3 positionButt = sphereButt.transform.position;

        // lineRenderer.SetPosition(0, positionHead);
        // lineRenderer.SetPosition(1, position1);
        // lineRenderer.SetPosition(2, position2);
        // lineRenderer.SetPosition(3, positionButt);


  
    }
}
