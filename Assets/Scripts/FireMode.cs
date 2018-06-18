using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireMode : MonoBehaviour 
{
	public Text monitorOfFireMode;

	private string currentMode;

	void Start()
	{
		currentMode = "Auto";
	}

	void Update()
	{
		monitorOfFireMode.text = currentMode;
		if (Input.GetKeyDown (KeyCode.T)) 
		{
			ChangeFireMode ();
		}
	}

	public void ChangeFireMode()
	{
		if (currentMode == "Single") 
		{
			currentMode = "Auto";
		} 
		else 
		{
			currentMode = "Single";
		}
	}

	public string getCurrentMode()
	{
		return currentMode;
	}
}
