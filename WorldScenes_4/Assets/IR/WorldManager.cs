using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager {

    //Load scene from 1 to N
    public static bool LoadScene(int i)
    {
        //check if index is valid
        if(i<=0 && i>SceneManager.sceneCount)
        {
            return false;
        }

        //if the own scene is selected, ignore
        if(i==SceneManager.GetActiveScene().buildIndex)
        {
            Debug.LogError("Own scene selected");
            return false;
        }
        

        //ignore the start scenes
        SceneManager.LoadScene(i);

        return true;
    }
}
