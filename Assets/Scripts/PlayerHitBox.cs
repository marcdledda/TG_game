﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitBox : MonoBehaviour {

	[SerializeField]
	private Text wallText;
	[SerializeField]
	private GameObject dummyStart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "dodgePill"){
			Destroy(other.gameObject);
			wallText.text = "Starting Dexterity Test...";
			GameState.dexStart = true;
			GameState.countStart = true;
			movePillar.pillSpawn = false;
		}
		if(other.gameObject.tag == "dodgeBall"){
			GameState.dodgeScore--;
		}
		if(other.gameObject.tag == "gunPill"){
			Destroy(other.gameObject);
			wallText.text = "Finger Guns Enabled" + "\r\nShoot the Target to start...";
			leftGun.leftEnable = true;
			rightGun.rightEnable = true;
			Instantiate(dummyStart, new Vector3(-1.2f, 0f, 1.3f), Quaternion.Euler(new Vector3(-90f, 0f, 90f)));
		}
		if(other.gameObject.tag == "uniPill"){
			Destroy(other.gameObject);
			wallText.text = "Starting" + "\r\nDexterity & Reflex Test";
			GameState.uniStart = true;
			GameState.countStart = true;
			leftGun.leftEnable = true;
			rightGun.rightEnable = true;
			movePillar.pillSpawn = false;
		}
	}
}
