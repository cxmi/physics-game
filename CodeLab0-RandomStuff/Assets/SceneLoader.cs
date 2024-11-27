using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool isAdditive = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)){
        if(isAdditive){
             //can now put this inside of a collider/ontrigger enter
            //void OnTriggerEnter(collider other){}

            SceneManager.LoadScene("SphereScene", LoadSceneMode.Additive);
            // unload the scenes you dont need
            SceneManager.UnloadSceneAsync("HillValleyScene");
            //make sure you dont load a scene again if its already loaded
            if(SceneManager.GetSceneByName("SphereScene").isLoaded){
                return; //means to exit this program 
            }

            //Or just add a ! to the if and put the scenemanager lod unload code in the if brackets
        }
        else{
            SceneManager.LoadScene("SphereScene");
        }
      }  
    }
}


//case for a singleton - two cameras, one in each scene, but you want the camera from the first scene to persist
