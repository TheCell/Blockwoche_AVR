using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Follow : MonoBehaviour
{
    [SerializeField] private Transform HUDDisplay;
    [SerializeField] private float threshhold;
    [SerializeField] private float distance;
    [SerializeField] private float heightOffset;
    [SerializeField] private float widthOffset;

    private Transform cam;

    private void Start()
    {
        cam = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        HUDDisplay.LookAt(cam);
        var camForward = cam.forward;
        camForward.y = 0f;
        HUDDisplay.position = cam.position + camForward.normalized * distance;
        var panelHeight = cam.localPosition.y - heightOffset;
        var position = HUDDisplay.position;
        position.y = panelHeight > 0.2f ? panelHeight : 0.2f;
        position.x += widthOffset;
        HUDDisplay.RotateAround(HUDDisplay.position, HUDDisplay.up, 180f);
        HUDDisplay.position = position;
    }
}