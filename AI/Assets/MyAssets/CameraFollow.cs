using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public float CamMoveSpeed = 120f;
	public GameObject CameraFollowObj;
	Vector3 FollowPOS;
	public float clampAngle = 80f;
	public float InputSensivity = 150f;
	public GameObject CameraObj;
	public GameObject PlayerObj;
	public float CamDistanceXtoPlayer;
	public float CamDistanceYtoPlayer;
	public float CamDistanceZtoPlayer;
	public float MouseX;
	public float MouseY;
	public float finalInputX;
	public float finalInputZ;
	public float smoothX;
	public float smoothY;
	private float rotX=0.0f;
	private float rotY = 0.0f;

	// Use this for initialization
	void Start () {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotX = rot.x;
		rotY = rot.y;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

	}
	
	// Update is called once per frame
	void Update () {
		//we set up the rotation of the stick here
		float InputX = Input.GetAxis("RightStickHorizontal");
		float InputZ = Input.GetAxis ("RightStickVertival");
		MouseX = Input.GetAxis ("Mouse X");
		MouseY = Input.GetAxis ("Mouse Y");
		finalInputX = InputX + MouseX;
		finalInputZ = InputZ + MouseY;

		rotX += finalInputZ + InputSensivity * Time.deltaTime;
		rotY += finalInputX + InputSensivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX,clampAngle,-clampAngle);
		Quaternion LocalRotation = Quaternion.Euler(rotX,rotY,0.0f);
		transform.rotation = LocalRotation;

	}

	void lateUpdate () {
		CameraUpdater ();
	}

	void CameraUpdater(){
		//set the target object to follow
		Transform target = CameraFollowObj.transform;

		//move toward the object that is target
		float step = CamMoveSpeed*Time.deltaTime;
		transform.position=Vector3.MoveTowards (transform.position,target.position,step);
	}


}

