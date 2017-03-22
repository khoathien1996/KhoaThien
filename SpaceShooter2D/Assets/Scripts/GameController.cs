using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public float starWait, spawnWait;
	public int hazardCount;
	public GameObject asteroid;
	public Vector2 spawnValues;
	public float waveWait;
	public Text gameOverText;
	private bool gameOver;
	public GameObject player;
	// Use this for initialization
	void Start () {
		gameOver = false;
		gameOverText.text = "";
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);﻿
		}
	}
	IEnumerator SpawnWaves () {
		while (true) {
			yield return new WaitForSeconds (starWait);
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);
		}
	}

	public void GameOver(){
		gameOverText.text = "Game Over";
		Instantiate (player, player.transform.position , Quaternion.identity);
	}
}
