using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSpawn : MonoBehaviour {

	[SerializeField]
	private GameObject dummyPrefab;
	private bool afterCancel = false;

	// Use this for initialization
	void Start () {
		InvokeRepeating("spawnDummy", 0.5f, 0.5f);		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameState.dummyAmount == 0){
            CancelInvoke();
			afterCancel = true;
			GameState.spawnLast = true;
		}
		if (afterCancel){
			Destroy(gameObject);
		}
	}

	private void spawnDummy(){
		float positionX = Random.Range(-3.7f, -3f);
		float positionY = Random.Range(0f, 1.1f);
		Vector3 objectPos = new Vector3(positionX, positionY, -2.9f);

		Instantiate(dummyPrefab, objectPos, Quaternion.Euler(new Vector3(-90f, 0f, 90f)));
		GameState.dummyAmount--;
	}
}
