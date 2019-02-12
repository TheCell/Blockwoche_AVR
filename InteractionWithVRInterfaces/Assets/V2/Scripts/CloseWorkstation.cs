using Leap.Unity.Animation;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWorkstation : MonoBehaviour {
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
        StartCoroutine(lateAttach(waitTime));
    }

    IEnumerator lateAttach(float time)
    {
        yield return new WaitForSeconds(time);
        bool wasVisible = anchor.gameObject.activeSelf;
        if (!wasVisible)
        {
            anchor.gameObject.SetActive(true);
        }
        Debug.Log("Try Attach - Result:");
        Anchor pref = anchorableBehaviour.GetNearestValidAnchor(false);
        if (pref != null)
        {
            transform.position = pref.transform.position;

            bool result = anchorableBehaviour.TryAttachToNearestAnchor();
            Debug.Log(result);
        }
        if (!wasVisible)
        {
            anchor.gameObject.SetActive(false);
        }
    }
}
