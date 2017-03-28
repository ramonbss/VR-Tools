using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_around : MonoBehaviour {

	Transform Player;
	Transform Camera;
	private float last_rot_y = 0f;
	private float last_angle = 0f;

	void Start()
	{

		Player = transform.root;
		Camera = GameObject.Find("Head").transform;

		last_rot_y = Camera.rotation.y;
		last_angle = GetSignedAngle (Camera.rotation, transform.rotation, Vector3.up);
	}

	void Update()
	{
		float angle_parent_camera = GetSignedAngle(Player.rotation,Camera.rotation, Vector3.up);
		float angle_parent_panel = GetSignedAngle(Player.rotation,transform.rotation, Vector3.up);

		float angle = angle_parent_camera - angle_parent_panel;

		//Debug.Log ("Angle: " + angle);
		Debug.Log ("Signed Angle: " + angle);
		//Debug.Log ("Camera Angle: " + angle_c);

		//Debug.Log("Last y: " + ( last_rot_y - Camera.rotation.y ));

		gameObject.transform.RotateAround( Player.position, Vector3.up, angle);

		Debug.DrawRay (Player.position, Camera.forward);
		//Debug.DrawRay (Player.position, lookPos,Color.green);
		Debug.DrawRay (Player.position, gameObject.transform.forward,Color.black);
	
	}
		
	private static float GetSignedAngle(Quaternion A, Quaternion B, Vector3 axis) {
		float angle = 0f;
		Vector3 angleAxis = Vector3.zero;
		(B*Quaternion.Inverse(A)).ToAngleAxis(out angle, out angleAxis);
		if(Vector3.Angle(axis, angleAxis) > 90f) {
			angle = -angle;
		}
		return Mathf.DeltaAngle(0f, angle);
	}

	public void plus_90()
	{
		Player.transform.Rotate( Vector3.up, 90 );
		//
	}

	public void plus_180()
	{
		Player.transform.Rotate( Vector3.up, 180 );
	}

	public void minus_90()
	{
		Player.transform.Rotate( Vector3.up, -90 );
	}

}
