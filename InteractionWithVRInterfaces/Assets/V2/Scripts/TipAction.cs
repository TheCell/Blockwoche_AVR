using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipAction : MonoBehaviour
{
    private MeshRenderer gameObjectRenderer;

    private void Start()
    {
        gameObjectRenderer = GetComponent<MeshRenderer>();
    }

    public void SetMaterial(Material material)
    {
        gameObjectRenderer.material = material;
    }
}