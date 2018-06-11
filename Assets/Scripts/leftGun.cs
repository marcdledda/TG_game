using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftGun : MonoBehaviour {

	[SerializeField]
	private ParticleSystem muzzleFlash;
	[SerializeField]
	private Transform muzzlePos;
	[SerializeField]
	private GameObject sparkPrefab;
	[SerializeField]
	private GameObject impactPrefab;
	public static bool leftEnable;

	// Use this for initialization
	void Start () {
		leftEnable = false;
	}
	
	// Update is called once per frame
	void Update () {
		bool leftIndex = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
		// bool leftThumb = OVRInput.GetDown(OVRInput.Touch.PrimaryThumbRest);
		// bool leftMiddle = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);
		
		// if (!leftIndex && leftThumb && leftMiddle && leftEnable){
		// 	shoot();
		// }
		if (leftIndex && leftEnable){
			shoot();
		}
	}

	void shoot(){
		muzzleFlash.Play();

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
