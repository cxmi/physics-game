using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyEnter : MonoBehaviour
{

    public string inputName;
	Button buttonMe;
	// Use this for initialization
	void Start () {
		buttonMe = GetComponent<Button>();
	}
	
	void Update() {
		if(Input.GetButtonDown(inputName))
		{
			buttonMe.onClick.Invoke();
		}
			

	}
}
