using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachAttach : MonoBehaviour
{
    [SerializeField] private float detachAttachReuseDelay = 1f;
    [SerializeField] private float detachAttachActivationDelay = 0.5f;
    [SerializeField] private float idleColorAfterActivationDelay = 0.2f;
    private bool isActive = true;

    public bool IsActive
    {
        get { return isActive; }

        private set { isActive = value; }
    }

    public float DetachAttachActivationDelay
    {
        get { return detachAttachActivationDelay; }

        private set { detachAttachActivationDelay = value; }
    }

    public float IdleColorAfterActivationDelay
    {
        get { return idleColorAfterActivationDelay; }

        private set { idleColorAfterActivationDelay = value; }
    }

    public void Activated()
    {
        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay()
    {
        IsActive = false;
        yield return new WaitForSeconds(detachAttachReuseDelay);
        IsActive = true;
    }
}