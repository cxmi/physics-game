using System.Collections;
using UnityEngine;
using TMPro;

public class FadeTextMeshProWithCanvasGroup : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private TextMeshProUGUI textMeshPro;
    public float fadeDuration = 2f; // Duration for both fade-in and fade-out
    public float secondsOfDisplay = 5f;
    public float delayBeforeFade = 1f; // Delay before starting the fade-in

    void Start()
    {
        // Get the CanvasGroup and TextMeshProUGUI components attached to the GameObject
        canvasGroup = GetComponent<CanvasGroup>();
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // Make sure the initial alpha is set to 0 for the fade-in effect
        canvasGroup.alpha = 0f;

        // Ensure that TextMeshPro text color is fully opaque
        Color textColor = textMeshPro.color;
        textColor.a = 1f;
        textMeshPro.color = textColor;

        // Start the process with a delay
        StartCoroutine(DelayedFade());
    }

    IEnumerator DelayedFade()
    {
        // Wait for the specified delay before starting the fade
        yield return new WaitForSeconds(delayBeforeFade);

        // Start the fade-in process
        yield return StartCoroutine(FadeIn());

        // Wait for a specified time before starting the fade-out (e.g., 2 seconds)
        yield return new WaitForSeconds(secondsOfDisplay);

        // Start the fade-out process
        yield return StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        float startAlpha = 0f;
        float endAlpha = 1f;
        float startTime = Time.time;

        // Fade the CanvasGroup alpha to 1
        while (Time.time < startTime + fadeDuration)
        {
            float t = (Time.time - startTime) / fadeDuration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            yield return null;
        }

        // Ensure the alpha is set to 1 at the end
        canvasGroup.alpha = 1f;
    }

    IEnumerator FadeOut()
    {
        float startAlpha = 1f;
        float endAlpha = 0f;
        float startTime = Time.time;

        // Fade the CanvasGroup alpha to 0
        while (Time.time < startTime + fadeDuration)
        {
            float t = (Time.time - startTime) / fadeDuration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            yield return null;
        }

        // Ensure the alpha is set to 0 at the end
        canvasGroup.alpha = 0f;
    }
}