using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachAttach : MonoBehaviour {
    [SerializeField] private float detachAttachDelay = 0.5f;
    private bool isActive = true;
    public bool IsActive
    {
        get
        {
            return isActive;
        }

        private set
        {
            isActive = value;
        }
    }

    public void Activated()
    {
        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay()
    {
        IsActive = false;
        yield return new WaitForSeconds(detachAttachDelay);
        IsActive = true;
    }
}
