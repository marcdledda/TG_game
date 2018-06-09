using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitBox : MonoBehaviour {

	[SerializeField]
	private Text wallText;

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
	}
}
