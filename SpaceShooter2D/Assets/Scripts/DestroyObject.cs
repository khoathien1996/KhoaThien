﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
	}
}
