using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGrab : MonoBehaviour {

	public static string itemCollide;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other != null){
			itemCollide = other.gameObject.tag;
		}
	}

	void OnTriggerExit(Collider other){
		if (other != null){
			itemCollide = "blank";
		}
	}
}
