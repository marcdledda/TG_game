using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wallInstruct : MonoBehaviour {

	[SerializeField]
	private Text tutText;
	[SerializeField]
	private GameObject spawnObj;
	[SerializeField]
	private GameObject spawnGunObj;
	public static bool showInstruct;
	public static bool countStart;
	private float countdown = 3f;
	public static bool textShown;

	// Use this for initialization
	void Start () {
		showInstruct = false;
		countStart = false;
		textShown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (showInstruct && countStart){
			startTimer();
		}
		
		if (!textShown && GameState.dexStart){
			if (countdown < 2.64f){
				tutText.text = "DODGE";
			}
			if (countdown < 2.28f){
				tutText.text = "DODGE THE";
			}
			if (countdown < 1.92f){
				tutText.text = "DODGE THE SPHERES";
				startSpawn();
			}
		} else if (!textShown && GameState.gunStart){
			if (countdown < 2.64f){
				tutText.text = "SHOOT";
			}
			if (countdown < 2.28f){
				tutText.text = "SHOOT THE";
			}
			if (countdown < 1.92f){
				tutText.text = "SHOOT THE DUMMIES";
				startSpawn();
			}
		} else if (!textShown && GameState.uniStart) {
			if (countdown < 2.64f){
				tutText.text = "DODGE";
			}
			if (countdown < 2.28f){
				tutText.text = "DODGE AND";
			}
			if (countdown < 1.92f){
				tutText.text = "DODGE AND SHOOT";
				startSpawn();
			}
		} else if (!textShown){
			tutText.text = "";
		}
	}

	private void startTimer(){
		if (Mathf.Round(countdown) != 0f){
			countdown -= Time.deltaTime;
		} else {
			countStart = false;
			countdown = 3f;
		}
	}

	private void startSpawn(){
		if (!textShown && GameState.dexStart) {
			textShown = true;
			Vector3 objectPos = new Vector3(0f, 0f, 0f);
			Instantiate(spawnObj, objectPos, Quaternion.identity);

		} else if (!textShown && GameState.gunStart) {
			textShown = true;
			Vector3 objectPos = new Vector3(0f, 0f, 0f);
			Instantiate(spawnGunObj, objectPos, Quaternion.identity);

		} else if (!textShown && GameState.uniStart) {
			textShown = true;
			Vector3 objectPos = new Vector3(0f, 0f, 0f);
			Instantiate(spawnObj, objectPos, Quaternion.identity);
			Instantiate(spawnGunObj, objectPos, Quaternion.identity);
			
		}
	}
}
