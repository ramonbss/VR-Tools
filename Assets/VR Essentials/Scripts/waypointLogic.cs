using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointLogic : MonoBehaviour {

	public GameObject player;				// Here is our player/main camera
	public float player_height = 2;			// The distance between camera and ground. This allow us to maintain the height when traveling through waypoints with differents heights

	public bool teleport_move = true;		// Activate teleport between waypoints. When not enabled the user will travel with a linear velocity
	public float maxMoveDistance = 10;		// Max distance allowed to travel
	//public float time_to_travel = .8f;		// The time spent by traveling between the waypoints. It's the inverse of the velocity, the less the faster
	public float speed = .8f;

	public void Move(GameObject waypoint) {
		if (!teleport_move) {

			// Time is the inversal of velocity. Using the same distance, more speed means less time to travel
			float time_to_travel = Mathf.Abs(speed - 1f);

			iTween.MoveTo (player, 
				iTween.Hash (
					"position", new Vector3 (waypoint.GetComponent<Transform> ().position.x, waypoint.GetComponent<Transform> ().position.y + player_height / 2, waypoint.GetComponent<Transform> ().position.z), 
					"time", speed, 
					"easetype", "linear"
				)
			);
		} else {
			player.transform.position = new Vector3 (waypoint.GetComponent<Transform> ().position.x, waypoint.GetComponent<Transform> ().position.y + player_height / 2, waypoint.GetComponent<Transform> ().position.z);
		}
	}
}
