using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePillar : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private GameObject pillPrefab;
	public static bool move;
	public static bool moveBack;
	public static bool pillSpawn;

	// Use this for initialization
	void Start () {
		move = false;
		moveBack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (move){
			transform.Translate(Vector3.down * Time.deltaTime * speed);
			if (transform.position.y < -1.2f){
				move = false;
			}
		}

		if (moveBack){
			transform.Translate(Vector3.up * Time.deltaTime * speed);
			if (transform.position.y > -0.1f){
				moveBack = false;
				if (!pillSpawn){
					Vector3 objectPos = new Vector3(0f, 1.348f, 0.486f);
					Instantiate(pillPrefab, objectPos, Quaternion.identity);
					pillSpawn = true;
				}
			}
		}
	}
}
