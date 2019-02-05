using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{

	public LayerMask layer;
	public ParticleSystem hitParticleSystem;
	private Vector3 previousPosition;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
		{
			if (Vector3.Angle(transform.position - previousPosition, hit.transform.up) > 130)
			{
				hitParticleSystem.Play();
				Destroy(hit.transform.gameObject);
			}
		}

		previousPosition = transform.position;
	}
}
