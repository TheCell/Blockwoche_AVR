using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineID : MonoBehaviour
{
	[SerializeField]
	private int machineID;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public int getMachineID()
	{
		return this.machineID;
	}
}
