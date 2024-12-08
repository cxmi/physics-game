using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class EndGameScript : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (PixelCrushers.DialogueSystem.DialogueLua.GetVariable("rollCredits").AsBool == true){
            //slight delay?
            
            //change to ending scene
        }

    }
}
