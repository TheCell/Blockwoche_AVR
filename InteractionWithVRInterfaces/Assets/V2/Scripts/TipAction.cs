using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipAction : MonoBehaviour {
    [SerializeField] private Material detachUI;
    [SerializeField] private Material attachUI;

    private MeshRenderer gameObjectRenderer;
    // Use this for initialization
    void Start () {
        gameObjectRenderer = GetComponent<MeshRenderer>();
        gameObjectRenderer.material = detachUI;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setMaterial (bool attachmentHands)
    {
        if (attachmentHands)
        {
            gameObjectRenderer.material = detachUI;
        }
        else
        {
            gameObjectRenderer.material = attachUI;
        }
    }
}
