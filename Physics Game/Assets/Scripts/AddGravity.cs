using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;



public class AddGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private VariableScript variableScript;
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log ("player touched this");
        rb = GetComponent<Rigidbody>();
        if (rb != null && variableScript.canHitRecord){
            rb.useGravity = true;
            //set play music for august quest to successful
            PixelCrushers.DialogueSystem.QuestLog.SetQuestState("Play music for August", QuestState.Success);
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("playedMusic", true);
            //add a delay here
            //PixelCrushers.DialogueSystem.QuestLog.SetQuestState("Talk to August again", QuestState.Active);
        }

    }
}
