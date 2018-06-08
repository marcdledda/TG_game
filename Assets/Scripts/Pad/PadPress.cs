using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadPress : MonoBehaviour {

	private bool primeIndexPoint;
	private bool secondIndexPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		primeIndexPoint = OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger);
		secondIndexPoint = OVRInput.Get(OVRInput.NearTouch.SecondaryIndexTrigger);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "LHand"){
			if (!primeIndexPoint){
				checkGameMode();
			}
		}

		if(other.gameObject.tag == "RHand"){
			if (!secondIndexPoint){
				checkGameMode();
			}
		}
	}

	private void checkGameMode(){
		Debug.Log("press");
	}

}
