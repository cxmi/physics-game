using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class VariableScript : MonoBehaviour
{
    public bool canHitRecord = false;
    public bool playedMusic = false;
    public bool canTurnOffLight = false;
    public bool turnedOffLight = false;
    public bool finishedMeetingLuke = false;
    public bool enteredAugustRoomFinal = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Play music for August") == QuestState.Active){
            canHitRecord = true;
        }

        if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Turn off the lights") == QuestState.Active){
            canTurnOffLight = true;
        }

        if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Meet August and Luke in bed") == QuestState.Active){
            finishedMeetingLuke = true;
        }

        
    }
}
