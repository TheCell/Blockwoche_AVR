using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbActions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        TipAction tipAction = other.gameObject.GetComponent<TipAction>();
        if (tipAction != null)
        {
            Debug.Log("Detatch UI");
        }
    }
}
