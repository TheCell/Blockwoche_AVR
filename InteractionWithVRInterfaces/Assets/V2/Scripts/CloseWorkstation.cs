using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWorkstation : MonoBehaviour {
    [SerializeField] private AnchorableBehaviour anchorableBehaviour;

    public void AttachToParrentIfPossible()
    {
        anchorableBehaviour.TryAttachToNearestAnchor();
    }
}
