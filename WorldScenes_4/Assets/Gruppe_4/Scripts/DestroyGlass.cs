using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGlass : MonoBehaviour
{
	public Falldown falldownScript;
	public int sceneNumber;

	// Use this for initialization
	void Start ()
	{
		falldownScript = GetComponent<Falldown>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
		falldownScript.startFalldown(sceneNumber);
	}
}
