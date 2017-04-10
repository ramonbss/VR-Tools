using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Moviments : MonoBehaviour {

	public Transform MainCamera;
	public float sensitivity = .5f;

	public bool click_teleport = false;
	public bool auto_walk = false;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.Find ("Main Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {

		if ( click_teleport && Input.GetMouseButton(0)) {      //This works with the cardboard trigger too.
			transform.Translate( MainCamera.forward * sensitivity);
		}

	}
}
