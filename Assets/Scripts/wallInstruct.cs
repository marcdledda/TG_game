using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wallInstruct : MonoBehaviour {

	[SerializeField]
	private Text tutText;
	public static bool showInstruct;
	public static bool countStart;
	private float countdown = 3f;
	private bool textShown = false;

	// Use this for initialization
	void Start () {
		showInstruct = false;
		countStart = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (showInstruct && countStart){
			startTimer();
		}
		
		if (!textShown){
			if (countdown < 2.64f){
				tutText.text = "DODGE";
			}
			if (countdown < 2.28f){
				tutText.text = "DODGE THE";
			}
			if (countdown < 1.92f){
				tutText.text = "DODGE THE SPHERES";
				textShown = true;
			}
		}
	}

	private void startTimer(){
		if (Mathf.Round(countdown) != 0f){
			countdown -= Time.deltaTime;
		} else {
			countStart = false;
		}
	}
}
