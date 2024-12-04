using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugustHider : MonoBehaviour
{
    public GameObject sittingAugust;
    [SerializeField] private VariableScript variableManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // the script we made created the class VariableScript
        // so we drag that in and now can reference the variables within 
        if (!variableManager.finishedMeetingLuke){
            sittingAugust.SetActive(false); 
        }
    }
}
