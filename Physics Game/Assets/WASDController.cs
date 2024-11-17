using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDController : MonoBehaviour
{
    public float speed = 0.1f;

    public KeyCode keyRight = KeyCode.D;
    public KeyCode keyLeft = KeyCode.A;
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyDown = KeyCode.S;

    // Rigidbody rb;
    // public float jumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    Debug.Log("Hello again!");
        //get the current position
        Vector3 pos = transform.position;

        if(Input.GetKey(keyRight)){
            //Move to the right
            pos.x += speed;
        }

        if(Input.GetKey(keyLeft)){
            //Move to the right
            pos.x -= speed;
        }

        if(Input.GetKey(keyUp)){
            //Move to the right
            pos.z += speed;
        }

        if(Input.GetKey(keyDown)){
            //Move to the right
            pos.z -= speed;
        }
        //set the transform.position to the new position 
        transform.position = pos;    

    }


}
