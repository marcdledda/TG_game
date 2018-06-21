﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightGun : MonoBehaviour {

	[SerializeField]
	private ParticleSystem muzzleFlash;
	[SerializeField]
	private Transform muzzlePos;
	[SerializeField]
	private GameObject sparkPrefab;
	[SerializeField]
	private GameObject impactPrefab;
	[SerializeField]
	private LineRenderer laser;
	public static bool rightEnable;
	private AudioSource gunSound;

	// Use this for initialization
	void Start () {
		rightEnable = false;
		gunSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		bool rightIndex = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
		// bool rightThumb = OVRInput.GetDown(OVRInput.Touch.SecondaryThumbRest);
		// bool rightMiddle = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);
		
		// if (!rightIndex && rightThumb && rightMiddle && rightEnable){
		// 	shoot();
		// }
		if (rightIndex && rightEnable){
			if (checkGrab.itemCollide != "uniPill"){
				shoot();
			}
		}
		if (rightEnable){
			laser.enabled = true;
		} else {
			laser.enabled = false;
		}
	}

	void shoot(){
		muzzleFlash.Play();
		gunSound.Play();
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit)){
			GameObject impactCreate = Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactCreate, 2.5f);
			
			if (hit.transform.tag == "dummyStart"){
				Destroy(hit.transform.gameObject);
			}
			if (hit.transform.tag == "dummy"){
				Destroy(hit.transform.gameObject);
				GameState.gunScore++;
			}
		}
		// Vector3 sparkPos = muzzlePos.position;
		// GameObject sparkCreate = Instantiate(sparkPrefab, sparkPos, Quaternion.Euler(new Vector3(0f, -90f, 0f)));
		// Destroy(sparkCreate, 3f);
	}
}
