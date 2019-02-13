using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attachments;

public class ThumbActions : MonoBehaviour {
    [SerializeField] private AttachmentHands attachmentHandsUI;
    [SerializeField] private Material detachUI;
    [SerializeField] private Material attachUI;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private MeshRenderer meshRenderer;
    private DetachAttach detachAttach;

    private MeshRenderer gameObjectRenderer;

    private void Start()
    {
        gameObjectRenderer = GetComponent<MeshRenderer>();
        gameObjectRenderer.material = detachUI;
        detachAttach = GetComponentInParent<DetachAttach>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (detachAttach.IsActive)
        {
            TipAction tipAction = other.gameObject.GetComponent<TipAction>();
            if (tipAction != null)
            {
                detachAttach.Activated();
                attachmentHandsUI.enabled = !attachmentHandsUI.enabled;
                tipAction.SetMaterial(attachmentHandsUI.enabled);
                SetColor();
            }
        }
    }

    private void SetColor()
    {
        if (attachmentHandsUI.enabled)
        {
            meshRenderer.enabled = true;
            gameObjectRenderer.material = detachUI;
        }
        else
        {
            meshRenderer.enabled = false;
            gameObjectRenderer.material = attachUI;
            particleSystem.Play();
        }
    }
}
