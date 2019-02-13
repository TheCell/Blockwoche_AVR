﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineDisplayCheck : MonoBehaviour
{
	[SerializeField]
	private GameObject[] machinePanels;
	[SerializeField]
	private GameObject noMachinesForPanelsSymbol;
	[SerializeField]
	private Material interactableMaterial;
	[SerializeField]
	private Material interactableActiveMaterial;

	// Use this for initialization
	void Start ()
	{
		hideAllPanels();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void DisplayAllInteractibles()
	{
        Debug.Log("display Interactibles");
        GameObject[] interactibleGameObjects = GameObject.FindGameObjectsWithTag("interactibleObject");
		for (int i = 0; i < interactibleGameObjects.Length; i++)
		{
            MeshRenderer objectRenderer = interactibleGameObjects[i].GetComponent<MeshRenderer>();
            objectRenderer.enabled = true;

            var interactibleRenderer = interactibleGameObjects[i].GetComponent<Renderer>();
			if (interactibleRenderer != null)
			{
				interactibleRenderer.material = this.interactableMaterial;
			}
		}
	}

	public void HideAllInteractibles()
	{
        Debug.Log("Hide Interactibles");
		GameObject[] interactibleGameObjects = GameObject.FindGameObjectsWithTag("interactibleObject");
		for (int i = 0; i < interactibleGameObjects.Length; i++)
		{
            MeshRenderer objectRenderer = interactibleGameObjects[i].GetComponent<MeshRenderer>();
            objectRenderer.enabled = false;
		}
	}

    private void OnTriggerStay(Collider other)
    {
        MachineID machineNumber = other.GetComponent<MachineID>();

        if (machineNumber != null)
        {
            hideAllPanels();
            int machineID = machineNumber.getMachineID();
            //Debug.Log(machineID);
            displayPanel(machineID);
        }
        else
        {
            hideAllPanels();
            noMachinesForPanelsSymbol.SetActive(true);
            //Debug.Log("Collider " + other.gameObject.name + " has no MachineID Script");
        }
    }

    private void OnTriggerEnter(Collider other)
	{
        Renderer boxRenderer = other.GetComponent<Renderer>();

        if (boxRenderer != null && other.gameObject.CompareTag("interactibleObject"))
		{
            Debug.Log("Boxcollision");
			boxRenderer.material = this.interactableActiveMaterial;
		}
	}

	private void OnTriggerExit(Collider other)
	{
        Renderer boxRenderer = other.GetComponent<Renderer>();

        if (boxRenderer != null && other.gameObject.CompareTag("interactibleObject"))
		{
			boxRenderer.material = this.interactableMaterial;
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
			//Debug.Log("Machine with ID " + panelID + " does not exist");
		}
	}

	private void hideAllPanels()
	{
		for (int i = 0; i < machinePanels.Length; i++)
		{
			machinePanels[i].SetActive(false);
			noMachinesForPanelsSymbol.SetActive(false);
		}
	}
}
