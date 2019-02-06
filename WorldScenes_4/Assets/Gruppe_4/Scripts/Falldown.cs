using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falldown : MonoBehaviour
{
	public float unitsToFall = 500;
	private GameObject cameraRig;
	private float fallTime = 1.0f;
	private float startFallingTime;
	private bool isFalling = false;
	private bool started = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private int sceneNumber;

	// Use this for initialization
	void Start ()
	{
		cameraRig = gameObject;
		startPosition = transform.position;
		endPosition = transform.position - Vector3.up * unitsToFall;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isFalling)
		{
			FallDown();
		}
	}

	public void startFalldown(int sceneNumber)
	{
		this.sceneNumber = sceneNumber;
		isFalling = true;
		startFallingTime = Time.realtimeSinceStartup;
	}

	void FallDown()
	{
		if (startFallingTime < Time.realtimeSinceStartup)
		{
			float endTime = startFallingTime + fallTime;
			float currentTime = Time.realtimeSinceStartup;
			float lerpT = (1 / (endTime - startFallingTime)) * (currentTime - startFallingTime);

			if (endTime > currentTime)
			{
				Vector3 currentPosition = startPosition;
				currentPosition.y = Mathf.Lerp(startPosition.y, endPosition.y, lerpT);
				transform.position = currentPosition;
			}
			else
			{
				WorldManager.LoadScene(this.sceneNumber);
			}
		}
	}
}
