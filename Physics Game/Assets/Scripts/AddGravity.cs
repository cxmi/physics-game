using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;



public class AddGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private VariableScript variableScript;
    [SerializeField] GameObject musicScriptObject;
    private bool swappedTrack = false;


    void OnCollisionEnter(Collision collision)
    {
        
        //Debug.Log ("player touched this");
        rb = GetComponent<Rigidbody>();
        if (rb != null && variableScript.canHitRecord){
            rb.useGravity = true;
            //set play music for august quest to successful
            PixelCrushers.DialogueSystem.QuestLog.SetQuestState("Play music for August", QuestState.Success);
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("playedMusic", true);
            MusicController controller = musicScriptObject.GetComponent<MusicController>();

            if (!swappedTrack){
                swappedTrack = true;
                controller.SwapTrack();
            }

            //add a delay here
            //PixelCrushers.DialogueSystem.QuestLog.SetQuestState("Talk to August again", QuestState.Active);
        }

    }

    void Update()
    {
        
        //debug
        //    if(Input.GetKey(KeyCode.F)){
        //     //Move to the right
        //     //pos.x += speed * Time.deltaTime;

        //     PixelCrushers.DialogueSystem.DialogueLua.SetVariable("playedMusic", true);
        // }

            if (PixelCrushers.DialogueSystem.DialogueLua.GetVariable("playedMusic").AsBool == true){
                Debug.Log("playedMusic variable is now true");
            }
    }
}
