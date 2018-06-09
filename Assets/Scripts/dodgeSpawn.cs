using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeSpawn : MonoBehaviour {

	[SerializeField]
	private int dodgeAmount;
	[SerializeField]
	private GameObject ballPrefab;


	// Use this for initialization
	void Start () {
		InvokeRepeating("spawnBall", 0.5f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (dodgeAmount == 0){
            CancelInvoke();
		}
	}

	private void spawnBall(){
		float positionX = Random.Range(-3.7f, -2.2f);
		float positionZ = Random.Range(-1.6f, 1.6f);
		float positionY = Random.Range(0.27f, 2f);
		Vector3 objectPos = new Vector3(positionX, positionY, positionZ);

		Instantiate(ballPrefab, objectPos, Quaternion.identity);
		dodgeAmount--;
	}
}
