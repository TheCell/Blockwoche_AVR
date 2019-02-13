using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDSettingsLogic : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private TextMeshPro showHUD;

    private void Start()
    {
    }

    public void ToggleHud()
    {
        var substring = GetSubstring(showHUD.text);

        if (hud.activeSelf)
        {
            hud.SetActive(false);
            showHUD.text = "Show " + substring;
        }
        else
        {
            hud.SetActive(true);
            showHUD.text = "Hide " + substring;
        }
    }

    private string GetSubstring(string s)
    {
        return s.Substring(s.IndexOf(' '));
    }
}