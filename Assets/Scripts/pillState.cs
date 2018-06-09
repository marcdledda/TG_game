using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pillState : MonoBehaviour {

	[SerializeField]
	private Rigidbody pillObject;
	[SerializeField]
	private float speedForce;
	[SerializeField]
	private Text pillText;
	private bool leftIndex;
	private bool leftMiddle;
	private bool rightIndex;
	private bool rightMiddle;
	private Vector3 originalPos;
	private bool grabbing;

	// Use this for initialization
	void Start () {
		grabbing = false;
		originalPos = new Vector3(0f, 1.348f, 0.486f);
	}
	
	// Update is called once per frame
	void Update () {
		leftIndex = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
		leftMiddle = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);
		rightIndex = OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
		rightMiddle = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

		if (checkGrab.itemCollide != "dodgePill"){
			if (!leftIndex && !leftMiddle || !rightIndex && !rightMiddle){
				pillText.text = "";
				if (transform.position != originalPos){
					Vector3 towardPos = originalPos - transform.position;
					pillObject.AddForce(speedForce*towardPos);
				}
			}
		} else if (checkGrab.itemCollide == "dodgePill"){
			if (leftIndex && leftMiddle || rightIndex && rightMiddle){
				pillText.text = "Dexterity Test";
			}
		}
		

	}
}
