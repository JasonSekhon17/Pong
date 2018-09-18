using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float speed = 7.5f;

	private Game game;

	// Use this for initialization
	void Start () {
		game = GameObject.Find ("Game").GetComponent<Game> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -15) {
			game.playerTwoPoint ();
			game.reset ();
		} else if (transform.position.x > 15) {
			game.playerOnePoint ();
			game.reset ();
		}
	}

	public void LaunchBall(){
		float sx = Random.Range (0, 2) == 0 ? -1 : 1;
		float sy = Random.Range (0, 2) == 0 ? -1 : 1;
		GetComponent<Rigidbody> ().velocity = new Vector3 (speed * sx, speed * sy, 0f);
	}
}
