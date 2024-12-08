using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EpilogueManager : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float fadeDuration = 2f; // Duration for the fade-in effect
    [SerializeField] private float secondsToWait = 0f;

    void Start()
    {
        // Get the CanvasGroup component attached to the GameObject
        canvasGroup = GetComponent<CanvasGroup>();


        // Start the fade-in process
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float startAlpha = 0f;
        float endAlpha = 1f;
        float startTime = Time.time;

        while (Time.time < startTime + fadeDuration)
        {
            float t = (Time.time - startTime) / fadeDuration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            yield return null;
        }

        // Ensure the alpha is set to 1 at the end
        canvasGroup.alpha = 1f;
    }
}
