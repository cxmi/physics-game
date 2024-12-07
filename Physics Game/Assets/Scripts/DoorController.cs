using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject lukeDoorHinge;
    [SerializeField] private GameObject lukeDoorStatic;
    [SerializeField] private GameObject toiletDoorHinge;
    [SerializeField] private GameObject toiletDoorStatic;
    [SerializeField] private GameObject augustDoorHinge;
    [SerializeField] private GameObject augustDoorStatic;

    void Start(){
        //hingeJoints = GetComponent<HingeJoint>();
    }
    // Update is called once per frame
    void Update()
    {
        //open toilet door after you get quest to find apartment 
        if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Find who lives in the apartment") == QuestState.Active){
            //make hinge door inactive and make static door active
            toiletDoorStatic.SetActive(false);
            toiletDoorHinge.SetActive(true);
        }

        //close august's door during the record player quest
        if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Play music for August") == QuestState.Active){
            augustDoorHinge.SetActive(false);
            augustDoorStatic.SetActive(true);
        }

        //open both august and luke's door when you get the quest to meet luke
         if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Meet Luke") == QuestState.Active){
            lukeDoorStatic.SetActive(false);
            lukeDoorHinge.SetActive(true);
            augustDoorStatic.SetActive(false);
            augustDoorHinge.SetActive(true);
        }

        //close august's door once you start talking to luke
        if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Turn off the lights") == QuestState.Active || 
        PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Go back to Luke") == QuestState.Active ){
            augustDoorHinge.SetActive(false);
            augustDoorStatic.SetActive(true);
        }

        //open august's door once you get the final convo to meet on his bed
        if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Meet August and Luke in bed") == QuestState.Active){
            augustDoorStatic.SetActive(false);
            augustDoorHinge.SetActive(true);
        }



    }
}
