using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Follow : MonoBehaviour
{
    [SerializeField] private Transform panel;
    [SerializeField] private float threshhold;
    [SerializeField] private float distance;
    [SerializeField] private float height;

    private Transform cam;

    private void Start()
    {
        cam = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        panel.LookAt(cam);
        panel.position = cam.position + cam.forward * distance;
        var panelHeight = cam.localPosition.y - height;
        var position = panel.position;
        position.y = panelHeight > 0.2f ? panelHeight : 0.2f;
        panel.position = position;
    }
}