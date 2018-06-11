using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startDummy : MonoBehaviour {

	private Text wallText;

	// Use this for initialization
	void Start () {
		wallText = GameObject.Find("Start/Load").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy(){
		wallText.text = "Starting Reflex Test...";
		GameState.gunStart = true;
		GameState.countStart = true;
		movePillar.pillSpawn = false;
	}
}
