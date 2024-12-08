using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class MouseHider : MonoBehaviour
{

    [SerializeField] private GameObject mouseHolder;
    private float elapsedTime = 0f;
    [SerializeField] private float lengthOfTime = 10f;


    // Update is called once per frame
    void Update()
    {

        if (PixelCrushers.DialogueSystem.QuestLog.GetQuestState("Look at the mirror") == QuestState.Active){
            elapsedTime += Time.deltaTime;
            if (elapsedTime < lengthOfTime){
                mouseHolder.SetActive(true);
            }
            else{
                mouseHolder.SetActive(false);
            }
        }

    }
}
