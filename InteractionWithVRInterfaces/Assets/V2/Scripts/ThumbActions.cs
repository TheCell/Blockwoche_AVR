using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attachments;

public class ThumbActions : MonoBehaviour {
    [SerializeField] private AttachmentHands attachmentHandsUI;
    [SerializeField] private Material detachUI;
    [SerializeField] private Material attachUI;

    private MeshRenderer gameObjectRenderer;

    private void Start()
    {
        MeshRenderer gameObjectRenderer = GetComponent<MeshRenderer>();
        gameObjectRenderer.material = detachUI;
    }

    private void OnTriggerEnter(Collider other)
    {
        TipAction tipAction = other.gameObject.GetComponent<TipAction>();
        if (tipAction != null)
        {
            Debug.Log("Detatch UI");
            attachmentHandsUI.enabled = !attachmentHandsUI.enabled;
            if (attachmentHandsUI.enabled)
            {
                gameObjectRenderer.material = detachUI;
            }
            else
            {
                gameObjectRenderer.material = attachUI;
            }
        }
    }
}
