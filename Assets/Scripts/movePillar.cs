using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePillar : MonoBehaviour {

	[SerializeField]
	private float speed;
	public static bool move;
	public static bool moveBack;

	// Use this for initialization
	void Start () {
		move = false;
		moveBack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (move){
			transform.Translate(Vector3.down * Time.deltaTime * speed);
			if (transform.position.y == -1.2f){
				move = false;
			}
		}
	}
}
