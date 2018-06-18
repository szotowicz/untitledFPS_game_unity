using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour 
{
	public Animator Animator;
	public float TimeToReload = 2.2f;
	public Text MonitorTotallyCapcity;
	public Text MonitorMagazineAmmuniton;

	public int AmmunitionAvailableInMagazine = 20;
	private int magazineCapacity = 30;
	private int ammunitionAvailable = 100;
	//private int totallyCapacity = 300;

	void FixedUpdate ()
	{
		MonitorMagazineAmmuniton.text = AmmunitionAvailableInMagazine.ToString ();

		string prefix = "";
		if (ammunitionAvailable / 10 < 1) 
		{
			prefix = "00";
		} 
		else if (ammunitionAvailable / 10 < 10) 
		{
			prefix = "0";	
		}
		MonitorTotallyCapcity.text = prefix + ammunitionAvailable.ToString ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R) && AmmunitionAvailableInMagazine != magazineCapacity && ammunitionAvailable > 0) 
		{
			StartCoroutine (Reload ());
		}
	}

	public void Decrement()
	{
		AmmunitionAvailableInMagazine--;
	}

	IEnumerator Reload()
	{
		Animator.SetBool ("Reloading", true);
		AudioSource reloadSound = GetComponents<AudioSource> ()[1]; // [0] = shoot sound; [1] = reload sound
		reloadSound.mute = false;
		reloadSound.Play ();
		yield return new WaitForSeconds (TimeToReload);

		int howManyNeed = magazineCapacity - AmmunitionAvailableInMagazine;
		if (ammunitionAvailable >= howManyNeed) {
			AmmunitionAvailableInMagazine += howManyNeed;
			ammunitionAvailable -= howManyNeed;
		} 
		else 
		{
			AmmunitionAvailableInMagazine += ammunitionAvailable;
			ammunitionAvailable = 0;
		}

		Animator.SetBool ("Reloading", false);
	}
}
