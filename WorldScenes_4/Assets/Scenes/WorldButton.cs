using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldButton : MonoBehaviour {

	public void LoadScene(int i)
    {
        WorldManager.LoadScene(i);
    }
}
