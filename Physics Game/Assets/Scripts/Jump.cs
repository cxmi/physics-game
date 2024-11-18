using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce = 10f;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is on the ground
        //isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

        //jump code
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpUp();
        }   
    }

    void JumpUp()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);  // Reset vertical velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // Apply jump force
    }

    // void OnCollisionEnter (Collision collision)
    // {
    //     isGrounded = true;
    // }
    // void OnCollisionExit (Collision collision)
    // {
    //     isGrounded = false;
    // }

    void OnCollisionStay (Collision collision){
         isGrounded = true;
    }
    
    void OnCollisionExit (Collision collision)
    {
        isGrounded = false;
    }
}
