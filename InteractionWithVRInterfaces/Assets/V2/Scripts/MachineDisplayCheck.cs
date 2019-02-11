using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineDisplayCheck : MonoBehaviour
{
	[SerializeField]
	GameObject[] machinePanels;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		MachineID machineNumber = other.GetComponent<MachineID>();
		if (machineNumber != null)
		{
			int machineID = machineNumber.getMachineID();
			Debug.Log(machineID);
			hideAllPanels();
			displayPanel(machineID);
		}
		else
		{
			Debug.Log("Collider " + other.gameObject.name + " has no MachineID Script");
		}
	}

	private void displayPanel(int panelID)
	{
		if (machinePanels[panelID] != null)
		{
			machinePanels[panelID].SetActive(true);
		}
		else
		{
			Debug.Log("Machine with ID " + panelID + " does not exist");
		}
	}

	private void hideAllPanels()
	{
		for (int i = 0; i < machinePanels.Length; i++)
		{
			machinePanels[i].SetActive(false);
		}
	}
}
