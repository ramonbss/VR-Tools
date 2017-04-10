using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Moviments : MonoBehaviour {

	public Transform Player;
	public void sensitivity = .5f;

	public bool click_teleport = false;
	public bool auto_walk = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {      //This works with the cardboard trigger too.
			Player.Translate(Vector3.forward * sensitivity);
		}
	}
}
