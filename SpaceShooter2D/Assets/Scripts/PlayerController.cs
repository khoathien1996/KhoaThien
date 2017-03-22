using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	public int speed;
	public float fireRate;
	private float nextFire;
	public Boundary boundary;
	public GameObject lightShot;
	Vector3 pos;

	void Start(){
		
		rb = GetComponent<Rigidbody2D> ();
		pos = rb.transform.position;
		Debug.Log (pos.x + "" + pos.y);
	} 
	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire){  //Fire1 default is Ctrl
			nextFire = Time.time + fireRate;	
			Instantiate (lightShot, rb.position , Quaternion.identity);
		}
	}
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb.position = new Vector2 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax)
		);
		rb.velocity = movement * speed;
	}
}
