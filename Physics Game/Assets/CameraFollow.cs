using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float xPosition = 0;
    public float yPosition = 8;
    public float zPosition = 0;
    public float CamMoveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position + new Vector3(xPosition, yPosition, zPosition);

        transform.position = Vector3.Lerp(player.transform.position + new Vector3(xPosition, yPosition, zPosition), 
        player.transform.position + new Vector3(xPosition, yPosition, zPosition), 
        CamMoveSpeed * Time.deltaTime);

        //Trans.position = Vector3.Lerp(Trans.position, _cam, CamMoveSpeed * Time.deltaTime);


    }
}
