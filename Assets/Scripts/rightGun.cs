using System.Collections;
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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool rightIndex = OVRInput.Get(OVRInput.NearTouch.SecondaryIndexTrigger);
		bool rightThumb = OVRInput.GetDown(OVRInput.Touch.SecondaryThumbRest);
		bool rightMiddle = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);
		
		if (!rightIndex && rightThumb && rightMiddle){
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
				Debug.Log("HIT DUMMY START");
			}
			if (hit.transform.tag == "dummy"){
				Debug.Log("HIT DUMMY");
			}
		}
		// Vector3 sparkPos = muzzlePos.position;
		// GameObject sparkCreate = Instantiate(sparkPrefab, sparkPos, Quaternion.Euler(new Vector3(0f, -90f, 0f)));
		// Destroy(sparkCreate, 3f);
	}
}
