using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    private void Start()
    {
        SetInactive();
    }

    public void SetActive()
    {
        foreach (var interactionButton in GetComponentsInChildren<InteractionButton>())
        {
            interactionButton.controlEnabled = true;
        }
    }

    public void SetInactive()
    {
        foreach (var interactionButton in GetComponentsInChildren<InteractionButton>())
        {
            interactionButton.controlEnabled = false;
        }
    }
}