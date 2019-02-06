using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectRandomScene : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        int i = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        Debug.Log("Selecting " + i +" of " + (SceneManager.sceneCountInBuildSettings-1));
        WorldManager.LoadScene(i);
    }
}
