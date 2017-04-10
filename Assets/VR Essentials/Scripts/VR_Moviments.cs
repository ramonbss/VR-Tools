using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Moviments : MonoBehaviour {

	public Transform MainCamera;
	public float motion_speed = .5f;

	// Movements mode

	public bool click_teleport = false;
	public bool auto_walk = false;

	private bool is_auto_walking = false;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.Find ("Main Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {


		// 1- Check for teleport motion
		if ( click_teleport && Input.GetMouseButtonDown(0)) {      //This works with the cardboard trigger too.
			transform.Translate( MainCamera.forward * motion_speed);
		}
		// 2- Check for auto walk
		else if( auto_walk )
		{
			// 2.1- When user click, start/stop motion
			if (Input.GetMouseButtonDown (0)) {
				// 2.1.1- Toggle auto walking mode
				is_auto_walking = !is_auto_walking;
			}

			// 2.2- If enabled, apply motion character controller
			if (is_auto_walking == true) {

				// 2.2.1- Get controller reference
				CharacterController controller = GetComponent<CharacterController> ();
				// 2.2.2- Get forward direction
				Vector3 forward = MainCamera.TransformDirection (Vector3.forward);
				// 2.2.3- Apply speed into movement
				Vector3 motion = forward * motion_speed;
				// 2.2.4- Do movement
				controller.SimpleMove (motion);
			}
		}

	}
}
