using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

	public GameObject player;

	void LateUpdate ()
	{
		Vector3 currentPosition = player.transform.position;
		currentPosition.y = transform.position.y;

		transform.position = currentPosition;
		transform.rotation = Quaternion.Euler (90f, player.transform.eulerAngles.y, 0f);
	}
}
