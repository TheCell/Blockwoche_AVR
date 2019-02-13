using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MachineDisplayCheck : MonoBehaviour
{
    [SerializeField] private GameObject[] machinePanels;
    [SerializeField] private GameObject noMachinesForPanelsSymbol;
    [SerializeField] private Material interactableMaterial;
    [SerializeField] private Material interactableActiveMaterial;

    private GameObject[] allInteractibleGameObjects;
    private float timer;

    // Use this for initialization
    private void Start()
    {
        HideAllPanels();
        allInteractibleGameObjects = GameObject.FindGameObjectsWithTag("interactibleObject");
        HideAllInteractibles();
    }

    public void DisplayAllInteractibles()
    {
        for (int i = 0; i < allInteractibleGameObjects.Length; i++)
        {
            MeshRenderer objectRenderer = allInteractibleGameObjects[i].GetComponent<MeshRenderer>();
            objectRenderer.enabled = true;

            var interactibleRenderer = allInteractibleGameObjects[i].GetComponent<Renderer>();
            if (interactibleRenderer != null)
            {
                interactibleRenderer.material = this.interactableMaterial;
            }
        }
    }

    public void HideAllInteractibles()
    {
        for (int i = 0; i < allInteractibleGameObjects.Length; i++)
        {
            MeshRenderer objectRenderer = allInteractibleGameObjects[i].GetComponent<MeshRenderer>();
            objectRenderer.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (timer > 0.5f)
        {
            MachineID machineNumber = other.GetComponent<MachineID>();

            if (machineNumber != null)
            {
                HideAllPanels();
                int machineID = machineNumber.getMachineID();
                //Debug.Log(machineID);
                DisplayPanel(machineID);
            }
            else
            {
                HideAllPanels();
                noMachinesForPanelsSymbol.SetActive(true);
            }

            timer = 0f;
        }

        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Renderer boxRenderer = other.GetComponent<Renderer>();

        if (boxRenderer != null && other.gameObject.CompareTag("interactibleObject"))
        {
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

    private void DisplayPanel(int panelID)
    {
        if (machinePanels[panelID] != null)
        {
            machinePanels[panelID].SetActive(true);
        }
    }

    private void HideAllPanels()
    {
        for (int i = 0; i < machinePanels.Length; i++)
        {
            machinePanels[i].SetActive(false);
            noMachinesForPanelsSymbol.SetActive(false);
        }
    }
}