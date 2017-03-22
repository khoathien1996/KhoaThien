using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {
	public Rigidbody2D rb2d;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController> ();
		else
			Debug.Log ("Khong tim thay game controller");
		
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){ // other: the object that touches(..) with this.
		if (other.tag != "DestroyObject") {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
		if (other.tag == "Player") {
			gameController.GameOver ();
		}
	}
	void OnCollisionEnter2D(Collision2D col1) {
		print("OnCollisionEnter2D voi " + col1.gameObject.name);
	}


}

