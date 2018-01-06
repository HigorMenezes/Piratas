using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaController : MonoBehaviour {

	public float heightVert;
	public float speedVert;

	public float heightHorX;
	public float speedHorX;

	public float heightHorZ;
	public float speedHorZ;

	private float defaultHeight;
	private float defaultHorX;
	private float defaultHorZ;
	void Start () {
		defaultHeight = transform.position.y;
		defaultHorX = transform.position.x;
		defaultHorZ = transform.position.z;
	}
	

	void Update () {


		transform.position = new Vector3 (transform.position.x, 
			transform.position.y + Random.Range (speedVert * 0.7f, speedVert * 1.3f) * heightVert * Time.fixedDeltaTime, 
			transform.position.z);

		if (transform.position.y > defaultHeight + heightVert)
			speedVert = -Mathf.Abs(speedVert);

		if (transform.position.y < defaultHeight - heightVert)
			speedVert = Mathf.Abs(speedVert);;

		transform.position = new Vector3 (transform.position.x + Random.Range(speedHorX * 0.7f, speedHorX * 1.3f)*heightHorX*Time.fixedDeltaTime, 
			transform.position.y, 
			transform.position.z);

		if (transform.position.x > defaultHorX + heightHorX )
			speedHorX = -Mathf.Abs(speedHorX);

		if (transform.position.x < defaultHorX - heightHorX)
			speedHorX = Mathf.Abs(speedHorX);

		transform.position = new Vector3 (transform.position.x, 
			transform.position.y, 
			transform.position.z + Random.Range(speedHorZ * 0.7f, speedHorZ * 1.3f)*heightHorZ*Time.fixedDeltaTime);

		if (transform.position.z > defaultHorZ + heightHorZ )
			speedHorZ = -Mathf.Abs(speedHorZ);

		if (transform.position.z < defaultHorZ - heightHorZ)
			speedHorZ = Mathf.Abs(speedHorZ);

	}
}
