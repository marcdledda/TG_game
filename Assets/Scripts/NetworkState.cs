using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkState : MonoBehaviour {

	[SerializeField]
	private Text wallText;
	private string letterLibrary = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	private int playerNum;
	public static string playerName;
	public static bool createName = false;
	public static bool postScore = false;

	// Use this for initialization
	void Start () {
		playerNum = Random.Range(100, 1000);
		char letter = letterLibrary[Random.Range(1, letterLibrary.Length+1)];
		playerName = playerNum.ToString() + letter;
		wallText.text = "Welcome Subject " + playerName + "\r\nEat the Pill" + "\r\nto Start the Test";
	}
	
	// Update is called once per frame
	void Update () {
		if (createName){
			playerNum = Random.Range(100, 1000);
			char letter = letterLibrary[Random.Range(1, letterLibrary.Length+1)];
			playerName = playerNum.ToString() + letter;
			wallText.text = "Welcome Subject " + playerName + "\r\nEat the Pill" + "\r\nto Start the Test";
			createName = false;
		}
		
		if (postScore){
			StartCoroutine(SaveData());
			postScore = false;
		}	
	}

	IEnumerator SaveData(){
		WWWForm form = new WWWForm();
		form.AddField("playerName", playerName);
		form.AddField("DexScore", (int)GameState.dodgeScore);
		form.AddField("RefScore", GameState.gunScore);
		form.AddField("CompGrade", GameState.dodgeGrade);

        UnityWebRequest www = UnityWebRequest.Post("https://marcdl636.000webhostapp.com/PostScore.php", form);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
        }
	}
}
