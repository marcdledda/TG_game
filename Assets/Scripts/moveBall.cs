using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBall : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private Rigidbody ball;
	private bool fullGrow = false;
	private Vector3 playerPos;
	private int growTick;

	// Use this for initialization
	void Start () {
		playerPos = GameObject.Find("CenterEyeAnchor").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!fullGrow){
			transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
			if (transform.localScale.x > 0.21) {
				fullGrow = true;
			}
		} else if (fullGrow){
			Vector3 towardPos = playerPos - transform.position;
			ball.AddForce(speed*towardPos);
		}

		if (transform.position.x > 1.1f || transform.position.y > 2.8f || transform.position.y < -0.3f || transform.position.z > 2.2f || transform.position.z < -2.2f) {
			if (GameState.uniStart){
				if (GameState.dodgeAmount == 0 && GameState.dummyAmount == 0 && GameState.spawnLast){
					moveDivider.moveBack = true;
				}
			} else if (!GameState.uniStart){
				if (GameState.dodgeAmount == 0){
					moveDivider.moveBack = true;
					movePillar.moveBack = true;
				}
			}
			Destroy(gameObject);
		}
	}
}
