using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZAxisRotate : MonoBehaviour
{
    public GameObject img;
    public float rotationSpeed = 10f;
    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rt = img.GetComponent<RectTransform>();
        //rt.localRotation = Quaternion.Euler(0, 0, 1) * Time.deltaTime;

        //move the mouse thing back and forth
        rt.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // if (rt.transform.rotation.eulerAngles.z >= 15){
        //     rt.transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime);
        // }
        if (rt.transform.rotation.eulerAngles.z <= -15){
            //rt.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            Debug.Log("rotate debug");
        }

    }
}
