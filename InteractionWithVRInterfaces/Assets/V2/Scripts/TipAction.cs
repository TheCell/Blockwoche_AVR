using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipAction : MonoBehaviour {

    private MeshRenderer gameObjectRenderer;
    // Use this for initialization
    void Start () {
        gameObjectRenderer = GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMaterial(Material material)
    {
        gameObjectRenderer.material = material;
    }
}
