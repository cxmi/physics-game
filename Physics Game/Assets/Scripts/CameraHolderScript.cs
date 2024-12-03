using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolderScript : MonoBehaviour
{
    public GameObject objectToFollow;
    public float followDistance = 8f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = objectToFollow.transform.position.x;
        pos.y = objectToFollow.transform.position.y + followDistance;
        pos.z = objectToFollow.transform.position.z;
        transform.position = pos;    

    }
}
