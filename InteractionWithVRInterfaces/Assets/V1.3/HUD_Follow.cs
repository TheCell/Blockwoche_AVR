using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Follow : MonoBehaviour
{
    [SerializeField] private Transform panel;
    [SerializeField] private float threshhold;

    private Transform cam;
    private Vector3 distance;

    private void Start()
    {
        cam = GetComponent<Transform>();
        distance = panel.position - cam.position;
    }

    private void LateUpdate()
    {
        panel.LookAt(cam);
        panel.position = cam.position + distance;
    }
}