using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class AugustMusicController : MonoBehaviour
{
    [SerializeField] GameObject musicScriptObject;

    // void Update(){
    //     if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Play music for August") == QuestState.Success){
    //         MusicController controller = musicScriptObject.GetComponent<MusicController>();
    //         //controller.augustMusic.Play();
    //         controller.SwapTrack();
    //     }

    // }

    private void OnTriggerEnter(Collider other)
    {
        //only activate this if you have already played music for august
        if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Play music for August") == QuestState.Success){
            if (other.CompareTag("Player")){
                //SwapTrack();
                MusicController controller = musicScriptObject.GetComponent<MusicController>();
                //if (controller.isPlayingBackgroundMusic){
                    controller.SwapTrack();
                //}
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //only activate this if you have already played music for august
        if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Play music for August") == QuestState.Success){
            if (other.CompareTag("Player")){
                //SwapTrack();
                MusicController controller = musicScriptObject.GetComponent<MusicController>();
                //if (controller.isPlayingBackgroundMusic){
                    controller.SwapTrack();
                //}
            }
        }
    }
}
