using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInMain : MonoBehaviour {

	private float speed = 2.0f;
	public GameObject target;

	void FixedUpdate () {
		transform.LookAt (target.transform);
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.Translate (Vector3.right * speed * Time.fixedDeltaTime);
		}else if (Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate (Vector3.right * -speed * Time.fixedDeltaTime);
		}
		
	}
}
