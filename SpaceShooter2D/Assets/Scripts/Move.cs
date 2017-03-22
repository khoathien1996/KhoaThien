using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	Rigidbody2D rb;
	public int speed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	
	// Update is called once per frame
	void Update () {
		//rb.AddForce (new Vector2 (0, 2.0f));
		rb.velocity = new Vector2(0f, 1f) * speed;
	}
}
