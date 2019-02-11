using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attachments;

public class ThumbActions : MonoBehaviour {
    [SerializeField] private AttachmentHands attachmentHandsUI;

    private void OnTriggerEnter(Collider other)
    {
        TipAction tipAction = other.gameObject.GetComponent<TipAction>();
        if (tipAction != null)
        {
            Debug.Log("Detatch UI");
            attachmentHandsUI.enabled = !attachmentHandsUI.enabled;
        }
    }
}
