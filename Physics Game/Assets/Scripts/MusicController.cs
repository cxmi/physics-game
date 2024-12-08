using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] public AudioSource augustMusic;
    [SerializeField] public bool isPlayingBackgroundMusic;
    [SerializeField]   float timeToFade = 0.25f;
    public AudioClip backgroundClip;
    // Start is called before the first frame update
    void Start()
    {
        isPlayingBackgroundMusic = true;
        backgroundMusic.Play();

        //SwapTrack();
    }

    // Update is called once per frame
    void Update()
    {
        //debug - testing the switching
          if(Input.GetKeyDown(KeyCode.M)){
            SwapTrack();
        }   
    }

    public void SwapTrack(){

        StopAllCoroutines();
        StartCoroutine(FadeTrack());
        isPlayingBackgroundMusic = !isPlayingBackgroundMusic;
        // if(isPlayingBackgroundMusic){
        //     //augustMusic.clip = newClip;
        //     backgroundMusic.Stop();
        //     augustMusic.Play();
        // }
        // else{
        //     //backgroundMusic.clip = newClip;
        //     backgroundMusic.Play();
        //     augustMusic.Stop();
        // }
        // isPlayingBackgroundMusic = !isPlayingBackgroundMusic;
    }

    public void ReturnToBackgroundMusic(){
        SwapTrack();
    }

    private IEnumerator FadeTrack(){
        //float timeToFade = 0.25f;
        float timeElapsed = 0f;

        if(isPlayingBackgroundMusic){
            augustMusic.Play();

            while(timeElapsed < timeToFade)
            {
                augustMusic.volume = Mathf.Lerp(0, 1, timeElapsed/timeToFade);
                backgroundMusic.volume = Mathf.Lerp(1, 0, timeElapsed/timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            backgroundMusic.Stop();

        }
        else{
            //backgroundMusic.clip = newClip;
            backgroundMusic.Play();
            while(timeElapsed < timeToFade)
            {
                backgroundMusic.volume = Mathf.Lerp(0, 1, timeElapsed/timeToFade);
                augustMusic.volume = Mathf.Lerp(1, 0, timeElapsed/timeToFade);
                timeElapsed += Time.deltaTime;

                yield return null;
            }    

            augustMusic.Stop();
        }

    }
}
