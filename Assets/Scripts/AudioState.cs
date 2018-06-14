using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioState : MonoBehaviour {

	[SerializeField]
	private GameObject dividerObj;
	private AudioSource[] divideSounds;

	// Use this for initialization
	void Start () {
		divideSounds = dividerObj.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (moveDivider.move && !divideSounds[0].isPlaying || moveDivider.moveBack && !divideSounds[0].isPlaying){
			divideSounds[0].Play();
		}
		if (!moveDivider.move && !moveDivider.moveBack && divideSounds[0].isPlaying && !divideSounds[1].isPlaying){
			divideSounds[0].Stop();
			divideSounds[1].Play();
		}
	}
}
