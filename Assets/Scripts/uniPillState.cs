using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uniPillState : MonoBehaviour {

	[SerializeField]
	private Rigidbody pillObject;
	[SerializeField]
	private float speedForce;
	[SerializeField]
	private Text pillText;
	private Vector3 originalPos;

	// Use this for initialization
	void Start () {
		originalPos = new Vector3(0f, 1.348f, 0.486f);
	}
	
	// Update is called once per frame
	void Update () {
		bool leftIndex = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
		bool leftMiddle = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);
		bool rightIndex = OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
		bool rightMiddle = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

		if (checkGrab.itemCollide != "uniPill"){
			if (!leftIndex && !leftMiddle || !rightIndex && !rightMiddle){
				pillText.text = "";
				if (transform.position != originalPos){
					Vector3 towardPos = originalPos - transform.position;
					pillObject.AddForce(speedForce*towardPos);
				}
			}
		} else if (checkGrab.itemCollide == "uniPill"){
			if (leftIndex && leftMiddle || rightIndex && rightMiddle){
				pillText.text = "Dexterity + Reflex";
			}
		}

	}
}
