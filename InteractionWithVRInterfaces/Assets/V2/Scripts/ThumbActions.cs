using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attachments;

public class ThumbActions : MonoBehaviour
{
    [SerializeField] private AttachmentHands attachmentHandsUI;
    [SerializeField] private Material dettachAttach;
    [SerializeField] private Material passive;
    [SerializeField] List<GameObject> connectParticleObject;
    private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
    private List<ParticleSystem> particleSystems = new List<ParticleSystem>();

    private DetachAttach detachAttach;

    private MeshRenderer gameObjectRenderer;

    private void Start()
    {
        gameObjectRenderer = GetComponent<MeshRenderer>();
        gameObjectRenderer.material = dettachAttach;
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
                tipAction.SetMaterial(dettachAttach);
                gameObjectRenderer.material = dettachAttach;
                HandleConnection();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TipAction tipAction = other.gameObject.GetComponent<TipAction>();
        if (tipAction != null)
        {
            tipAction.SetMaterial(passive);
            gameObjectRenderer.material = passive;
        }
    }

    private void SetColor()
    {
        if (attachmentHandsUI.enabled)
        {
            gameObjectRenderer.material = dettachAttach;
        }
        else
        {
            gameObjectRenderer.material = passive;
        }
    }

    private void HandleConnection()
    {
        if (attachmentHandsUI.enabled)
        {
            enableMeshRenderer();
        }
        else
        {
            playParticleEffect();
        }
    }

    private void enableMeshRenderer()
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = true;
        }
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Clear();
        }
    }

    private void playParticleEffect()
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = false;
        }
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Play();
        }
    }
}
