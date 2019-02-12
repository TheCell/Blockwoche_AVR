using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWorkstation : MonoBehaviour {
    private AnchorableBehaviour anchorableBehaviour;

    private void Start()
    {
        anchorableBehaviour = GetComponent<AnchorableBehaviour>();
    }

    public void AttachToParrentIfPossible()
    {

        

        Debug.Log("Try Attach - Result:");
        Anchor pref = anchorableBehaviour.GetNearestValidAnchor(false);

        Debug.Log(pref);
        transform.position = pref.transform.position;
        bool result = anchorableBehaviour.TryAttachToNearestAnchor();
        Debug.Log(result);
    }
}
