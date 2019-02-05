using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject cubeRed;
	public GameObject cubeBlue;
	public Transform[] pointsLeft;
	public Transform[] pointsRight;
	public float beat = (60/130) * 2;
	public float timer;
	private int previousAngleRed = 90;
	private int previousAngleBlue = 90;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer>beat)
		{
			GameObject cube;

			// Random 50/50 left or right
			if (Random.value < 0.5)
			{
				// Random 10/90 to have blue or red
				if (Random.value < 0.1)
				{
					cube = Instantiate(cubeBlue, pointsLeft[Random.Range(0, pointsLeft.Length)]);
				}
				else
				{
					cube = Instantiate(cubeRed, pointsLeft[Random.Range(0, pointsLeft.Length)]);
				}
			}
			else
			{
				// Random 10/90 to have red or blue 
				if (Random.value < 0.1)
				{
					cube = Instantiate(cubeRed, pointsLeft[Random.Range(0, pointsLeft.Length)]);
				}
				else
				{
					cube = Instantiate(cubeBlue, pointsRight[Random.Range(0, pointsRight.Length)]);

				}
			}

			int angle = 90 * Random.Range(0, 4);

			if (cube.name.ToLower().Contains("blue"))
			{
				if (previousAngleBlue == angle)
				{
					angle += 90;
				}

				previousAngleBlue = angle;
			}
			else
			{
				if (previousAngleRed == angle)
				{
					angle += 90;
				}

				previousAngleRed = angle;
			}
			
			cube.transform.localPosition = Vector3.zero;
			cube.transform.Rotate(transform.forward, angle);
			timer -= beat;
		}

		timer += Time.deltaTime;
	}
}
