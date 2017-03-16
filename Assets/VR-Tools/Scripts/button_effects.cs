﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class button_effects : MonoBehaviour {

	public bool anim_backgroun = false,	// Enable button's background animation
				anim_text = false;		// Enable button's text animation

	public Color Enter_Color = new Color(0.74f,0.74f,0.74f);	// When gaze enter button
	public Color Exit_Color = new Color(1f,1f,1f);				// When gaze exit button

	public Color Text_Enter = new Color(0f,0f,1f);				// When gaze enter button
	public Color Text_Exit = new Color(0f,0f,0f);				// When gaze exit button

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void onEnter()
	{
		//Debug.Log ("onEnter - " + gameObject.transform.name);
		Debug.Log("Color: " + Enter_Color.ToString());
		if( anim_backgroun )
			GetComponent<Image>().color = Enter_Color;

		if ( anim_text )
			GetComponentInChildren<Text> ().color = Text_Enter;

	}

	public void onExit()
	{
		//Debug.Log ("onExit - " + gameObject.transform.name);
		if( anim_backgroun )
			GetComponent<Image>().color = Exit_Color;

		if ( anim_text )
			GetComponentInChildren<Text> ().color = Text_Exit;

	}

}
