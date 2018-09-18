using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour {

	public float speed = 9f;

	public bool isPlayer;
	float floor;
	float roof;

	GameObject ball;
	Vector2 ballPos;

	// Use this for initialization
	void Start () {
		if (!isPlayer) {
			ball = GameObject.FindGameObjectWithTag ("Ball");
			floor = GameObject.FindGameObjectWithTag ("Floor").transform.position.y;
			roof = GameObject.FindGameObjectWithTag ("Roof").transform.position.y;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayer)
			transform.Translate (0f, Input.GetAxis ("Vertical2") * speed * Time.deltaTime, 0f);
		else
			Move ();
	}

	void Move(){
		ballPos = ball.transform.localPosition;
		if (transform.localPosition.y > floor && ballPos.y < transform.localPosition.y) {
			transform.localPosition += new Vector3 (0f, -speed * Time.deltaTime, 0f);
		}

		if (transform.localPosition.y < roof && ballPos.y > transform.localPosition.y) {
			transform.localPosition += new Vector3 (0f, speed * Time.deltaTime, 0f);
		}
	}
}