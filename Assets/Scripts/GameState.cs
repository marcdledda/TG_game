using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public static bool dexStart;
	public static bool countStart;
	private float countdown = 3f;

	// Use this for initialization
	void Start () {
		dexStart = false;
		countStart = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (dexStart && countStart){
			startTimer();
		}

		bool pressA = OVRInput.GetUp(OVRInput.Button.One);
		if (pressA){
			Debug.Log(dexStart);
			Debug.Log(countStart);
			Debug.Log(moveDivider.move);
		}
	}

	private void startTimer(){
		if (Mathf.Round(countdown) != 0f){
			countdown -= Time.deltaTime;
		} else {
			moveDivider.move = true;
			movePillar.move = true;
			countStart = false;
		}
	}
}
