﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attachments;

public class ThumbActions : MonoBehaviour
{
    [SerializeField] private AttachmentHands attachmentHandsUI;
    [SerializeField] private Material dettachAttachMat;
    [SerializeField] private Material idleMat;
    [SerializeField] private List<GameObject> connectParticleObject;

    private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
    private List<ParticleSystem> particleSystems = new List<ParticleSystem>();

    private float timetriggerstay;

    private TipAction tipAction;
    private DetachAttach detachAttach;
    private MeshRenderer gameObjectRenderer;

    private void Start()
    {
        gameObjectRenderer = GetComponent<MeshRenderer>();
        detachAttach = GetComponentInParent<DetachAttach>();
        foreach (GameObject particleObject in connectParticleObject)
        {
            meshRenderers.Add(particleObject.GetComponent<MeshRenderer>());
            particleSystems.Add(particleObject.GetComponent<ParticleSystem>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tipAction = other.gameObject.GetComponent<TipAction>();
        if (tipAction != null)
        {
            SetMaterial(idleMat);
            tipAction = null;
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
        if (tipAction != null)
        {
            timetriggerstay += Time.deltaTime;
            LerpMaterial();
            if (timetriggerstay >= detachAttach.DetachAttachActivationDelay)
            {
                DetachAttachUI();
            }
        }
    }

    private void DetachAttachUI()
    {
        detachAttach.Activated();
        attachmentHandsUI.enabled = !attachmentHandsUI.enabled;
        SetMaterial(dettachAttachMat);
        StartCoroutine(DelayIdleColour(detachAttach.IdleColorAfterActivationDelay, tipAction));
        HandleConnection();
        tipAction = null;
    }

    private IEnumerator DelayIdleColour(float time, TipAction tipAction)
    {
        yield return new WaitForSeconds(time);
        SetMaterial(idleMat, tipAction);
    }

    private void LerpMaterial()
    {
        float duration = detachAttach.DetachAttachActivationDelay;
        float lerp = Mathf.PingPong(timetriggerstay, duration) / duration;
        gameObjectRenderer.material.Lerp(idleMat, dettachAttachMat, lerp);
        SetMaterial(gameObjectRenderer.material);
    }

    private void SetMaterial(Material material)
    {
        SetMaterial(material, tipAction);
    }

    private void SetMaterial(Material material, TipAction tipAction)
    {
        tipAction.SetMaterial(material);
        gameObjectRenderer.material = material;
    }

    private void HandleConnection()
    {
        if (attachmentHandsUI.enabled)
        {
            EnableMeshRenderer();
        }
        else
        {
            PlayParticleEffect();
        }
    }

    private void EnableMeshRenderer()
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

    private void PlayParticleEffect()
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