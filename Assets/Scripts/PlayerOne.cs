using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour {
	
	public float speed = 7f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0f, Input.GetAxis ("Vertical") * speed * Time.deltaTime, 0f);
	}
}
