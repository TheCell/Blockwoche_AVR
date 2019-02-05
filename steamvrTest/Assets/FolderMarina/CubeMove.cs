using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Time.deltaTime * transform.forward * 2;
        
        //Garbage Collector
        if(transform.position.z <= -6)
        {
            Destroy(gameObject);
        }
		
	}
}
