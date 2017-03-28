using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_around : MonoBehaviour {

	Transform Player;				// GvrMain Reference
	Transform Camera;				// GvrMain's Head Reference

	void Start()
	{

		Player = transform.root;					// Apply GvrMain reference
		Camera = GameObject.Find("Head").transform;	// Apply Camera reference
	}

	void Update()
	{
		/**
		 * Obs: This code only work due GvrMain is static, when user rotate his head, only Head element move
		*/

		// 1 -  Get angle between GvrMain GameObject and Head
		float angle_parent_camera = GetSignedAngle(Player.rotation,Camera.rotation, Vector3.up);
		// 1.1- Get angle between GvrMain GameObject and Panel
		float angle_parent_panel = GetSignedAngle(Player.rotation,transform.rotation, Vector3.up);
		// 2- Get difference between 2 angles
		float angle = angle_parent_camera - angle_parent_panel;

		Debug.Log ("Signed Angle: " + angle); - Camera.rotation.y ));
		// 3- Update Panel rotation to it appear always in front of MainCamera
		gameObject.transform.RotateAround( Player.position, Vector3.up, angle);

		/*
		Debug.DrawRay (Player.position, Camera.forward);
		Debug.DrawRay (Player.position, gameObject.transform.forward,Color.black);
		*/
	
	}

	// Get signed angle between two rotation over a specific axe
	private static float GetSignedAngle(Quaternion A, Quaternion B, Vector3 axis) {
		float angle = 0f;
		Vector3 angleAxis = Vector3.zero;
		(B*Quaternion.Inverse(A)).ToAngleAxis(out angle, out angleAxis);
		if(Vector3.Angle(axis, angleAxis) > 90f) {
			angle = -angle;
		}
		return Mathf.DeltaAngle(0f, angle);
	}

	// Turn camera 90 degrees clockwise
	public void plus_90()
	{
		Player.transform.Rotate( Vector3.up, 90 );
		//
	}
	// Turn camera 90 degrees anti clockwise
	public void plus_180()
	{
		Player.transform.Rotate( Vector3.up, 180 );
	}
	// Turn camera 180 degrees clockwise
	public void minus_90()
	{
		Player.transform.Rotate( Vector3.up, -90 );
	}

}
