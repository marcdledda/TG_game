using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public static string dodgeGrade;

	public static float dodgeScore;
	public static int dodgeAmount;
	public static bool dexStart;

	public static bool gunStart;
	public static int dummyAmount;
	public static int gunScore;
	public static bool spawnLast;

	public static bool uniStart;

	public static bool countStart;
	private float countdown = 3f;

	// Use this for initialization
	void Start () {
		dexStart = false;
		gunStart = false;
		countStart = false;
		dodgeScore = 20f;
		dodgeAmount = 20;
		dummyAmount = 20;
		gunScore = 0;
		spawnLast = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (dexStart && countStart){
			startTimer();
		}

		if ((dodgeScore + gunScore) / 40f < 0.21f){
			dodgeGrade = "F";
		} else if ((dodgeScore + gunScore) / 40f < 0.41f){
			dodgeGrade = "D";
		} else if ((dodgeScore + gunScore) / 40f < 0.61f){
			dodgeGrade = "C";
		} else if ((dodgeScore + gunScore) / 40f < 0.81f){
			dodgeGrade = "B";
		} else if ((dodgeScore + gunScore) / 40f > 0.81f){
			dodgeGrade = "A";
		}

		if (gunStart && countStart){
			startTimer();
		}

		if (uniStart && countStart){
			startTimer();
		}

	}

	private void startTimer(){
		if (Mathf.Round(countdown) != 0f){
			countdown -= Time.deltaTime;
		} else {
			moveDivider.move = true;
			movePillar.move = true;
			countStart = false;
			countdown = 3f;
		}
	}
}
