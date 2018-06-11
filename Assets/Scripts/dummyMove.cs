using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
			if (GameState.dodgeAmount == 0 && GameState.dummyAmount == 0 && GameState.spawnLast){
				moveDivider.moveBack = true;
			}
		} else if (!GameState.uniStart){
			if (GameState.dummyAmount == 0 && GameState.spawnLast){
				moveDivider.moveBack = true;
				movePillar.moveBackUni = true;
			}
		}
	}
}
