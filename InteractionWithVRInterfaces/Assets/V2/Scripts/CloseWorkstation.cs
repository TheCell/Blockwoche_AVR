using Leap.Unity.Animation;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWorkstation : MonoBehaviour
{
    [SerializeField] private TransformTweenBehaviour transformTweenBehaviour;
    [SerializeField] private Anchor anchor;
    private AnchorableBehaviour anchorableBehaviour;


    private void Start()
    {
        anchorableBehaviour = GetComponent<AnchorableBehaviour>();
    }

    public void AttachToParrentIfPossible()
    {
        float waitTime = transformTweenBehaviour.tweenDuration;
        transformTweenBehaviour.PlayBackward();
        StartCoroutine(LateAttach(waitTime));
    }

    private IEnumerator LateAttach(float time)
    {
        yield return new WaitForSeconds(time);
        bool wasVisible = anchor.gameObject.activeSelf;
        if (!wasVisible)
        {
            anchor.gameObject.SetActive(true);
        }

        var nearestValidAnchor = anchorableBehaviour.GetNearestValidAnchor(false);
        if (nearestValidAnchor != null)
        {
            transform.position = nearestValidAnchor.transform.position;
            anchorableBehaviour.TryAttachToNearestAnchor();
        }

        if (!wasVisible)
        {
            anchor.gameObject.SetActive(false);
        }
    }
}