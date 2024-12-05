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
    public Camera myCamera;

    public Rigidbody rb;
    public float force = 1f;
    // public float jumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    //Debug.Log("Hello again!");
        //get the current position
        //Vector3 pos = transform.position;

        if(Input.GetKey(keyRight)){
            //Move to the right
            //pos.x += speed * Time.deltaTime;

            rb.AddForce(force * myCamera.transform.right * Time.fixedDeltaTime);

            //rb.AddForce(force * transform.right * Time.fixedDeltaTime);
        }

        if(Input.GetKey(keyLeft)){
            //Move to the right
            //pos.x -= speed * Time.deltaTime;
            rb.AddForce(force * -myCamera.transform.right * Time.fixedDeltaTime);
           // rb.AddForce(force * -transform.right * Time.fixedDeltaTime);

        }

        if(Input.GetKey(keyUp)){
            //Move to the right
            //pos.z += speed * Time.deltaTime;
            rb.AddForce(force * myCamera.transform.forward * Time.fixedDeltaTime);
            //rb.AddForce(force * transform.forward * Time.fixedDeltaTime);

        }

        if(Input.GetKey(keyDown)){
            //Move to the right
            //pos.z -= speed * Time.deltaTime;
            rb.AddForce(force * -myCamera.transform.forward * Time.fixedDeltaTime);
            //rb.AddForce(force * -transform.forward * Time.fixedDeltaTime);

        }
        //set the transform.position to the new position 
        //transform.position = pos;    

    }


}
