using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attachments;

public class ThumbActions : MonoBehaviour {
    [SerializeField] private AttachmentHands attachmentHandsUI;
    [SerializeField] private Material detachUI;
    [SerializeField] private Material attachUI;
    [SerializeField] private float delayTime;
    bool delayActive = false;

    private MeshRenderer gameObjectRenderer;

    private void Start()
    {
        gameObjectRenderer = GetComponent<MeshRenderer>();
        gameObjectRenderer.material = detachUI;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!delayActive)
        {
            TipAction tipAction = other.gameObject.GetComponent<TipAction>();
            if (tipAction != null)
            {
                Debug.Log("Detatch UI");
                attachmentHandsUI.enabled = !attachmentHandsUI.enabled;
                tipAction.setMaterial(attachmentHandsUI.enabled);
                if (attachmentHandsUI.enabled)
                {
                    gameObjectRenderer.material = detachUI;
                }
                else
                {
                    gameObjectRenderer.material = attachUI;
                }
            }
            StartCoroutine(DealyNextControll());
        }
    }

    IEnumerator DealyNextControll()
    {
        delayActive = true;
        yield return new WaitForSeconds(delayTime);
        delayActive = false;
    }
}
