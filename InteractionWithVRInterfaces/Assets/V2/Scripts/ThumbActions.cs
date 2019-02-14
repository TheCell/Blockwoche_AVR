using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attachments;

public class ThumbActions : MonoBehaviour
{
    [SerializeField] private AttachmentHands attachmentHandsUI;
    [SerializeField] private Material dettachAttachMat;
    [SerializeField] private Material passive;
    [SerializeField] List<GameObject> connectParticleObject;
    private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
    private List<ParticleSystem> particleSystems = new List<ParticleSystem>();
    float timetriggerstay = 0;
    TipAction tipAction = null;

    private DetachAttach detachAttach;

    private MeshRenderer gameObjectRenderer;

    private void Start()
    {
        gameObjectRenderer = GetComponent<MeshRenderer>();
        gameObjectRenderer.material = dettachAttachMat;
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
            tipAction = other.gameObject.GetComponent<TipAction>();
            if (tipAction != null)
            {
                timetriggerstay = 0;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(tipAction != null)
        {
            timetriggerstay += Time.deltaTime;

            //float lerp = Mathf.PingPong(timetriggerstay, detachAttach.DetachAttachActivationDelay) / detachAttach.DetachAttachActivationDelay;
            //gameObjectRenderer.material.Lerp(passive, dettachAttachMat, lerp);
            //SetMaterial(gameObjectRenderer.material);

            //Debug.Log(detachAttach.DetachAttachActivationDelay - timetriggerstay);
            if (timetriggerstay >= detachAttach.DetachAttachActivationDelay)
            {
                detachAttach.Activated();
                attachmentHandsUI.enabled = !attachmentHandsUI.enabled;
                SetMaterial(dettachAttachMat);
                HandleConnection();
                tipAction = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tipAction = other.gameObject.GetComponent<TipAction>();
        if (tipAction != null)
        {
            SetMaterial(passive);
            tipAction = null;
        }
    }

    private void SetMaterial(Material material)
    {
        tipAction.SetMaterial(material);
        gameObjectRenderer.material = material;
    }

    private void SetColor()
    {
        if (attachmentHandsUI.enabled)
        {
            gameObjectRenderer.material = dettachAttachMat;
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
