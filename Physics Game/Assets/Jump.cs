using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //jump code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpUp();
        }   
    }

    void JumpUp()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);  // Reset vertical velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // Apply jump force
    }
}
