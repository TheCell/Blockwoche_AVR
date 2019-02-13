using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attachments;

public class ThumbActions : MonoBehaviour
{
    [SerializeField] private AttachmentHands attachmentHandsUI;
    [SerializeField] private Material detachUI;
    [SerializeField] private Material attachUI;
    [SerializeField] List<GameObject> connectParticleObject;
    private List<MeshRenderer> meshRenderers;
    private List<ParticleSystem> particleSystems;

    private DetachAttach detachAttach;

    private MeshRenderer gameObjectRenderer;

    private void Start()
    {
        gameObjectRenderer = GetComponent<MeshRenderer>();
        gameObjectRenderer.material = detachUI;
        detachAttach = GetComponentInParent<DetachAttach>();
        foreach (GameObject particleObject in connectParticleObject)
        {
            meshRenderers.Add(particleObject.GetComponent<MeshRenderer>());
            particleSystems.Add(particleObject.GetComponent<ParticleSystem>());
        }
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
            enableMeshRenderer();
            gameObjectRenderer.material = detachUI;
        }
        else
        {
            playParticleEffect();
            gameObjectRenderer.material = attachUI;
        }
    }

    private void enableMeshRenderer()
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = true;
        }
    }

    private void playParticleEffect()
    {
        foreach(MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = false;
        }
        foreach(ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Play();
        }
    }
}
