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

	// Use this for initialization
	void Start () {
		move = false;
		moveBack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (move){
			transform.Translate(Vector3.up * Time.deltaTime * speed);
			if(transform.position.y > 4.22f){
				move = false;
				wallInstruct.showInstruct = true;
				wallInstruct.countStart = true;
			}
		}

		if (moveBack) {
			wallText.text = "Test Complete" + "\r\nDodged: " + GameState.dodgeScore + "/20" + "\r\nGrade: " + GameState.dodgeGrade;
			transform.Translate(Vector3.down * Time.deltaTime * speed);
			if(transform.position.y < 1.21f){
				moveBack = false;
				wallInstruct.showInstruct = false;
				wallInstruct.countStart = false;
				wallInstruct.textShown = false;
				GameState.dexStart = false;
				GameState.dodgeAmount = 20;
			}
		}
	}
}
