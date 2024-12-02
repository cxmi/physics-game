using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddGravity : MonoBehaviour
{
    Rigidbody rb;
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log ("player touched this");
        rb = GetComponent<Rigidbody>();
        if (rb != null){
            rb.useGravity = true;
        }

    }
}
