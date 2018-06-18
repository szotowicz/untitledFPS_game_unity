using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour 
{
	public float Damage = 10f;
	public float Range = 100f;
	public float FireRate = 8f;
	public Camera FpsCamera;
	public ParticleSystem FireButtle;
	public GameObject ImpactEffect;
	public float ImpactForce = 130f;

	private float nextTimeToFire = 0f;
	private Magazine myMagazine;
	private FireMode myFireMode;
	private bool canShoot;

	void Start()
	{
		myMagazine = GetComponent<Magazine> ();
		myFireMode = GetComponent<FireMode> ();
		canShoot = true;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire && myMagazine.AmmunitionAvailableInMagazine > 0 && canShoot)
		{
			canShoot = (myFireMode.getCurrentMode() == "Single" ? false : true);
			nextTimeToFire = Time.time + 1f / FireRate;
			Shoot ();
		}

		if (Input.GetKeyUp (KeyCode.Mouse0)) 
		{
			canShoot = true;
		}
	}

	private void Shoot()
	{
		FireButtle.Play ();

		AudioSource shootSound = GetComponents<AudioSource> ()[0]; // [0] = shoot sound; [1] = reload sound
		shootSound.mute = false;
		shootSound.Play ();

		RaycastHit hit;
		if (Physics.Raycast (FpsCamera.transform.position, FpsCamera.transform.forward, out hit, Range)) 
		{
			Destroy( Instantiate (ImpactEffect, hit.point, Quaternion.LookRotation (hit.normal)), 0.25f);

			Target target = hit.transform.GetComponent<Target> ();
			if (target != null) 
			{
				target.TakeDamage (Damage);
			}

			if (hit.rigidbody != null) 
			{
				hit.rigidbody.AddForce (-hit.normal * ImpactForce);
			}
		}

		myMagazine.Decrement ();
	}
}
