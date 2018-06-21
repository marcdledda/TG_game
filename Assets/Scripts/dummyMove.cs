using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyMove : MonoBehaviour {

	private bool spawnLast;

	// Use this for initialization
	void Start () {
		if (GameState.dummyAmount == 0){
			spawnLast = true;
		} else {
			spawnLast = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float speed = Random.Range(1.4f, 2.8f);
		transform.Translate(Vector3.left * Time.deltaTime * speed);
		if(transform.position.z > 2.9f){
			Destroy(gameObject);
		}
	}

	void OnDestroy(){
		if (GameState.uniStart) {
			if (GameState.dodgeAmount == 0 && GameState.dummyAmount == 0 && spawnLast){
				moveDivider.moveBack = true;
				NetworkState.postScore = true;
			}
		} else if (!GameState.uniStart){
			if (GameState.dummyAmount == 0 && spawnLast){
				moveDivider.moveBack = true;
				movePillar.moveBackUni = true;
			}
		}
	}
}
