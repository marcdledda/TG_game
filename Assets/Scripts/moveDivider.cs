using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveDivider : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private Text wallText;
	public static bool move;
	public static bool moveBack;
	public static bool moveBackRestart;	

	// Use this for initialization
	void Start () {
		move = false;
		moveBack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (move && GameState.dexStart){
			transform.Translate(Vector3.up * Time.deltaTime * speed);
			if(transform.position.y > 4.22f){
				move = false;
				wallInstruct.showInstruct = true;
				wallInstruct.countStart = true;
			}
		}

		if (move && GameState.gunStart){
			transform.Translate(Vector3.up * Time.deltaTime * speed);
			if(transform.position.y > 4.22f){
				move = false;
				wallInstruct.showInstruct = true;
				wallInstruct.countStart = true;
			}
		}

		if (move && GameState.uniStart){
			transform.Translate(Vector3.up * Time.deltaTime * speed);
			if(transform.position.y > 4.22f){
				move = false;
				wallInstruct.showInstruct = true;
				wallInstruct.countStart = true;
			}
		}

		if (moveBack && GameState.dexStart) {
			wallText.text = "Dodged: " + GameState.dodgeScore + "/15" + "\r\nEat The Next Pill";
			transform.Translate(Vector3.down * Time.deltaTime * speed);
			if(transform.position.y < 1.21f){
				moveBack = false;
				wallInstruct.showInstruct = false;
				wallInstruct.countStart = false;
				wallInstruct.textShown = false;
				GameState.dexStart = false;
				GameState.dodgeScore = 15f;
				GameState.dodgeAmount = 15;
			}
		}

		if (moveBack && GameState.gunStart){
			wallText.text = "Shot: " + GameState.gunScore + "/15" + "\r\nNow Do It In Unison";
			transform.Translate(Vector3.down * Time.deltaTime * speed);
			if(transform.position.y < 1.21f){
				moveBack = false;
				wallInstruct.showInstruct = false;
				wallInstruct.countStart = false;
				wallInstruct.textShown = false;
				GameState.gunStart = false;
				GameState.gunScore = 0;
				GameState.dummyAmount = 15;
				GameState.spawnLast = false;
			}
		}

		if (moveBack && GameState.uniStart){
			wallText.text = "Shot: " + GameState.gunScore + "/15" + "\r\nDodged: " + GameState.dodgeScore + "/15" + "\r\nComposite Score: " + GameState.dodgeGrade;
			transform.Translate(Vector3.down * Time.deltaTime * speed);
			if(transform.position.y < 1.21f){
				moveBack = false;
				wallInstruct.showInstruct = false;
				wallInstruct.countStart = false;
				wallInstruct.textShown = false;
				GameState.uniStart = false;
				GameState.dexStart = false;
				GameState.dodgeScore = 15f;
				GameState.dodgeAmount = 15;
				GameState.gunStart = false;
				GameState.gunScore = 0;
				GameState.dummyAmount = 15;
				GameState.spawnLast = false;
			}
		}

		if (moveBackRestart){
			wallText.text = "Eat the Pill" + "\r\nto Start the Test";
			moveBackRestart = false;
		}
	}
}
