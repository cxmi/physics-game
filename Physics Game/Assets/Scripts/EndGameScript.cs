using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;
using System.Drawing;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] GameObject heartImage;
    public GameObject heartCanvas;
    public Vector3 startScale = new Vector3(12f, 12f, 12f); // Starting scale (10x)
    public Vector3 endScale = new Vector3(2f, 2f, 2f); // Ending scale (2x)
    public float duration = 2f; // Duration in seconds

    private RectTransform rectTransform;
    private float elapsedTime = 0f;

    private SceneChanger sceneChanger;
    // Update is called once per frame


    void Start()
    {
        // Get the RectTransform component
        rectTransform = heartImage.GetComponent<RectTransform>();

        // Set the initial scale of the RectTransform
        if (rectTransform != null)
        {
            rectTransform.localScale = startScale;
        }
    }
    void Update()
    {
        sceneChanger = GetComponent<SceneChanger>();
        if (PixelCrushers.DialogueSystem.DialogueLua.GetVariable("rollCredits").AsBool == true){
            if (rectTransform == null) return;
            heartCanvas.SetActive(true);
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the interpolation factor (0 to 1)
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Interpolate the scale using Mathf.Lerp
            rectTransform.localScale = Vector3.Lerp(startScale, endScale, t);
            
            //slight delay?

            if (elapsedTime > 3){
                sceneChanger.ChangeScene("EndScene");
            }
        }

    }




}
