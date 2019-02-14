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

    private GameObject[] allInteractableGameObjects;
    private bool startShowing;
    private bool inInteractableBox;

    private void Start()
    {
        HideAllPanels();
        allInteractableGameObjects = GameObject.FindGameObjectsWithTag("InteractableObject");
        HideAllInteractibles();
    }

    public void DisplayAllInteractibles()
    {
        foreach (var interactableGameObject in allInteractableGameObjects)
        {
            MeshRenderer objectRenderer = interactableGameObject.GetComponent<MeshRenderer>();
            objectRenderer.enabled = true;

            var interactibleRenderer = interactableGameObject.GetComponent<Renderer>();
            if (interactibleRenderer != null)
            {
                interactibleRenderer.material = this.interactableMaterial;
            }
        }

        startShowing = false;
    }

    public void HideAllInteractibles()
    {
        foreach (var interactableGameObject in allInteractableGameObjects)
        {
            MeshRenderer objectRenderer = interactableGameObject.GetComponent<MeshRenderer>();
            objectRenderer.enabled = false;
        }

        startShowing = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (startShowing)
        {
            if (inInteractableBox)
            {
                MachineID machineNumber = other.GetComponent<MachineID>();

                if (machineNumber != null)
                {
                    HideAllPanels();
                    int machineID = machineNumber.GetMachineID();
                    DisplayPanel(machineID);
                }
            }

            if (!inInteractableBox)
            {
                HideAllPanels();
                noMachinesForPanelsSymbol.SetActive(true);
            }
        }
        else
        {
            Renderer boxRenderer = other.GetComponent<Renderer>();

            if (boxRenderer != null && other.gameObject.CompareTag("InteractableObject"))
            {
                boxRenderer.material = this.interactableActiveMaterial;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Renderer boxRenderer = other.GetComponent<Renderer>();

        if (boxRenderer != null && other.gameObject.CompareTag("InteractableObject"))
        {
            inInteractableBox = true;
            boxRenderer.material = this.interactableActiveMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Renderer boxRenderer = other.GetComponent<Renderer>();

        if (boxRenderer != null && other.gameObject.CompareTag("InteractableObject"))
        {
            inInteractableBox = false;
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
        foreach (var machinePanel in machinePanels)
        {
            machinePanel.SetActive(false);
        }

        noMachinesForPanelsSymbol.SetActive(false);
    }
}