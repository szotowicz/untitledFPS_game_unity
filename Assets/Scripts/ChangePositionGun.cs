using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionGun : MonoBehaviour 
{
	public GameObject crosshair;
	public float zoom = 0.3f;
	public Animator animator;
	private Vector3 previouslyRotation;
	private Vector3 previouslyPosition;

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Mouse1)) 
		{
			previouslyRotation = transform.localEulerAngles;
			previouslyPosition = transform.localPosition;

			//transform.localPosition = new Vector3 (0, transform.localPosition.y - 0.03f, transform.localPosition.z - zoom);
			//transform.localEulerAngles = new Vector3 (5, 0, 0);

			crosshair.SetActive (false);
			animator.SetBool ("Zooming", true);
		}

		if (Input.GetKeyUp (KeyCode.Mouse1)) 
		{
			transform.localPosition = previouslyPosition;
			transform.localEulerAngles = previouslyRotation;

			crosshair.SetActive (true);
			animator.SetBool ("Zooming", false);
		}
	}
}