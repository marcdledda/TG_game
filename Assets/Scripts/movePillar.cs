using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePillar : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private GameObject pillPrefab;
	[SerializeField]
	private GameObject uniPrefab;
	[SerializeField]
	private GameObject startPill;
	public static bool move;
	public static bool moveBack;
	public static bool pillSpawn;
	public static bool moveBackUni;
	public static bool moveBackRestart;

	// Use this for initialization
	void Start () {
		move = false;
		moveBack = false;
		moveBackUni = false;
		moveBackRestart = false;
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
					// pillPrefab.SetActive(true);
					pillSpawn = true;
				}
			}
		}

		if (moveBackUni){
			transform.Translate(Vector3.up * Time.deltaTime * speed);
			if (transform.position.y > -0.1f){
				moveBackUni = false;
				if (!pillSpawn){
					Vector3 objectPos = new Vector3(0f, 1.348f, 0.486f);
					Instantiate(uniPrefab, objectPos, Quaternion.identity);
					// uniPrefab.SetActive(true);
					pillSpawn = true;
				}
			}
		}

		if (moveBackRestart){
			transform.Translate(Vector3.up * Time.deltaTime * speed);
			if (transform.position.y > -0.1f){
				moveBackRestart = false;
				if (!pillSpawn){
					Vector3 objectPos = new Vector3(0f, 1.348f, 0.486f);
					Instantiate(startPill, objectPos, Quaternion.identity);
					// uniPrefab.SetActive(true);
					pillSpawn = true;
				}
			}
		}
	}
}
