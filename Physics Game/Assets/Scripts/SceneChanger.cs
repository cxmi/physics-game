using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene(string sceneName){
        //Debug.Log("Change to Scene:" + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
