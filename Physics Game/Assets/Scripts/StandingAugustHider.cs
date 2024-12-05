using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingAugustHider : MonoBehaviour
{
    [SerializeField] GameObject standingAugust;
    [SerializeField] private VariableScript variableManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (!variableManager.finishedMeetingLuke){
            standingAugust.SetActive(true); 
        }
        else {
            standingAugust.SetActive(false);
        }
    }
}
