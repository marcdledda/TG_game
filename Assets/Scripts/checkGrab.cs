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
		itemCollide = other.gameObject.name;
	}

	void OnTriggerExit(Collider other){
		itemCollide = "blank";
	}
}
