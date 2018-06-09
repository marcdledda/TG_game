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

	// Use this for initialization
	void Start () {
		playerPos = GameObject.Find("CenterEyeAnchor").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!fullGrow){
			transform.localScale = new Vector3(0.22f, 0.22f, 0.22f);
			fullGrow = true;
		} else if (fullGrow){
			Vector3 towardPos = playerPos - transform.position;
			ball.AddForce(speed*towardPos);
		}

		// if (transform.position.x > 1.7f || transform.position.y > 2.8f || transform.position.y > -0.4){
		// 	Destroy(gameObject);
		// }

		if (transform.position.x > 1.7f || transform.position.y > 2.8f || transform.position.y < -0.3f || transform.position.z > 2.2f || transform.position.z < -2.2f) {
			Destroy(gameObject);
		}
	}
}
