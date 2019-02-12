using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class RoomLogic : MonoBehaviour
{
    [SerializeField] private Light roomLight;
    [SerializeField] private TextMeshPro temperatureValue;

    private float ambientIntensity;
    private float reflectionIntensity;

    private void Start()
    {
        ambientIntensity = RenderSettings.ambientIntensity;
        reflectionIntensity = RenderSettings.reflectionIntensity;
    }

    public void ToogleRoomLight()
    {
        roomLight.enabled = !roomLight.enabled;
    }

    public void ToogleAmbientLight()
    {
        if (Math.Abs(RenderSettings.ambientIntensity) < 0.1)
        {
            RenderSettings.ambientIntensity = ambientIntensity;
            RenderSettings.reflectionIntensity = reflectionIntensity;
        }

        {
            RenderSettings.ambientIntensity = 0;
            RenderSettings.reflectionIntensity = 0;
        }
    }

    public void TemperatureSliderChanged(float temperate)
    {
        temperatureValue.text = temperate.ToString();
    }
}