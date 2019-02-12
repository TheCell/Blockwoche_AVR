using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelZoom : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void zoomIn()
	{
		Vector3 scale = panel.transform.localScale;
		scale.x += 0.3f;
		scale.y += 0.3f;
		scale.z += 0.3f;
		panel.transform.localScale = scale;
	}

	public void zoomOut()
	{
		Vector3 scale = panel.transform.localScale;
		if (scale.x > 0.4f)
		{
			scale.x -= 0.3f;
			scale.y -= 0.3f;
			scale.z -= 0.3f;
			panel.transform.localScale = scale;
		}
	}

	public void close()
	{

	}
}
