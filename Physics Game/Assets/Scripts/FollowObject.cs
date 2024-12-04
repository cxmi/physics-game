using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow = null;
    public GameObject img;
    private RectTransform rt;
    private Vector3 objectPos;
    public float yOffset = 0f;
    public float xOffset = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //objectPos.y = objectToFollow.GetComponent<Transform>().position.y;
   
    }

    // Update is called once per frame
    void Update()
    {
        rt = img.GetComponent<RectTransform>();
        objectPos = objectToFollow.GetComponent<Transform>().position;
        //rt = img.GetComponent<RectTransform>();
        rt.localPosition = objectPos + new Vector3(xOffset, yOffset, -1);
        //rt.localPosition -= new Vector3(0,0,8);
        
    }
}
