using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDivider : MonoBehaviour {

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
			transform.Translate(Vector3.up * Time.deltaTime * speed);
			if(transform.position.y > 4.22f){
				move = false;
				wallInstruct.showInstruct = true;
				wallInstruct.countStart = true;
			}
		}
	}
}
