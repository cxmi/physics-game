using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScroller : MonoBehaviour
{

    public RectTransform rectTransform;
    public float moveSpeed = 50f; // Speed at which the y position increases (units per second)

    void Update()
    {
        // Continuously move the y position upward based on moveSpeed and time
        float newY = rectTransform.anchoredPosition.y + (moveSpeed * Time.deltaTime);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);


        if (rectTransform.anchoredPosition.y > 3600){
                Application.Quit();
                Debug.Log("quit game");
        }
    }
}
