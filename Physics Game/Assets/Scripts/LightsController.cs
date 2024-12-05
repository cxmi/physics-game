using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class LightsController : MonoBehaviour
{
//[SerializeField] private VariableScript variableScript;
[SerializeField] private GameObject lightsOff;
[SerializeField] private GameObject lightsOn;

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log ("player touched this");
        if (PixelCrushers.DialogueSystem.DialogueLua.GetVariable("timeToTurnOffLights").AsBool == true){
            //rb.useGravity = true;
            //turn off the lights

            lightsOn.SetActive(false);
            lightsOff.SetActive(true);
            Debug.Log("working lights");
            //PixelCrushers.DialogueSystem.QuestLog.SetQuestState("Turn off the lights", QuestState.Success);
            //PixelCrushers.DialogueSystem.DialogueLua.SetVariable("timeToTurnOffLights", false);

//timeToTurnOffLights
            
            //add a delay here
            //PixelCrushers.DialogueSystem.QuestLog.SetQuestState("Talk to August again", QuestState.Active);
        }

    }
}
