using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDSettingsLogic : MonoBehaviour
{
	[SerializeField] private GameObject hud;
	[SerializeField] private TextMeshPro showHUD;
	[SerializeField] private GameObject temp;
	[SerializeField] private TextMeshPro showTemp;
	[SerializeField] private GameObject lights;
	[SerializeField] private TextMeshPro showLights;
	[SerializeField] private GameObject alarm;
	[SerializeField] private TextMeshPro showAlarm;

	private void Start()
    {
    }

	public void ToggleHud()
	{
		var substring = GetSubstring(showHUD.text);

		if (hud.activeSelf)
		{
			hud.SetActive(false);
			showHUD.text = "Show" + substring;
		}
		else
		{
			hud.SetActive(true);
			showHUD.text = "Hide" + substring;
		}
	}

	public void ToggleTemp()
	{
		var substring = GetSubstring(showTemp.text);

		if (temp.activeSelf)
		{
			temp.SetActive(false);
			showTemp.text = "Show" + substring;
		}
		else
		{
			temp.SetActive(true);
			showTemp.text = "Hide" + substring;
		}
	}

	public void ToggleLights()
	{
		var substring = GetSubstring(showLights.text);

		if (lights.activeSelf)
		{
			lights.SetActive(false);
			showLights.text = "Show" + substring;
		}
		else
		{
			lights.SetActive(true);
			showLights.text = "Hide" + substring;
		}
	}

	public void ToggleAlarm()
	{
		var substring = GetSubstring(showAlarm.text);

		if (alarm.activeSelf)
		{
			alarm.SetActive(false);
			showAlarm.text = "Show" + substring;
		}
		else
		{
			alarm.SetActive(true);
			showAlarm.text = "Hide" + substring;
		}
	}


	private string GetSubstring(string s)
    {
        return s.Substring(s.IndexOf(' '));
    }
}