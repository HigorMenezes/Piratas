using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInMenu : MonoBehaviour {

	public GameObject target;
	private float speed = 0.5f;


	void Update () {
		transform.LookAt (target.transform);
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}
