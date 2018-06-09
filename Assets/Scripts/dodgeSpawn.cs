using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeSpawn : MonoBehaviour {

	[SerializeField]
	private GameObject ballPrefab;
	private bool afterCancel = false;

	// Use this for initialization
	void Start () {
		InvokeRepeating("spawnBall", 0.5f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameState.dodgeAmount == 0){
            CancelInvoke();
			afterCancel = true;
		}
		if (afterCancel){
			Destroy(gameObject);
		}
	}

	private void spawnBall(){
		float positionX = Random.Range(-3.7f, -2.2f);
		float positionZ = Random.Range(-1.6f, 1.6f);
		float positionY = Random.Range(0.27f, 2f);
		Vector3 objectPos = new Vector3(positionX, positionY, positionZ);

		Instantiate(ballPrefab, objectPos, Quaternion.identity);
		GameState.dodgeAmount--;
	}
}
