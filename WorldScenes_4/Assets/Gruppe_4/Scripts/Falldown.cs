using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falldown : MonoBehaviour
{
	private GameObject cameraRig;
	private float fallTime = 1.0f;
	private float startFallingTime;
	private bool isFalling = false;
	private Vector3 startPosition;
	private Vector3 endPosition;

	// Use this for initialization
	void Start ()
	{
		cameraRig = gameObject;
		startPosition = transform.position;
		endPosition = transform.position - Vector3.up * 50;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isFalling)
		{
			startFalldown();
		}

		FallDown();
	}

	public void startFalldown()
	{
		isFalling = true;
		startFallingTime = Time.realtimeSinceStartup + 4;
	}

	void FallDown()
	{
		if (startFallingTime < Time.realtimeSinceStartup)
		{
			float endTime = startFallingTime + fallTime;
			float currentTime = Time.realtimeSinceStartup;
			float lerpT = (1 / (endTime - startFallingTime)) * (currentTime - startFallingTime);
			Debug.Log(lerpT);

			if (endTime > currentTime)
			{
				Vector3 currentPosition = startPosition;
				currentPosition.y = Mathf.Lerp(startPosition.y, endPosition.y, lerpT);
				transform.position = currentPosition;
			}
		}
	}
}
