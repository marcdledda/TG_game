using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public static bool dexStart;
	private float countdown = 3f;

	// Use this for initialization
	void Start () {
		dexStart = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dexStart && countdown != 0f){
			startTimer();
		}
	}

	private void startTimer(){
		if (countdown > 0f){
			countdown -= Time.deltaTime;
		} else {
			moveDivider.move = true;
			movePillar.move = true;
		}
	}
}
