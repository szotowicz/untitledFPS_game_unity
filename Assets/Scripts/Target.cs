using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour 
{
	public float HP = 50f;

	public void TakeDamage(float amount)
	{
		HP -= amount;
		if (HP <= 0) 
		{
			Destroy (gameObject);
		}
	}
}
