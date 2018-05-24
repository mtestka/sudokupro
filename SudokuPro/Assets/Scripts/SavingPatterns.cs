using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavingPatterns : MonoBehaviour {

	public GameObject[] patternTile;
	private GameHandler gh;
	public GameObject sceneMake, sceneEmpty;

	// Use this for initialization
	void Start () {
		gh = GameObject.FindObjectOfType<GameHandler> ().GetComponent<GameHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string PatternToString(){
		char[] ab = new char[81];
		for (int i = 0; i < 81; i++) {
			if (patternTile [i].GetComponent<Image> ().color == Color.white) {
				ab [i] = '0';
			} else {
				ab [i] = '1';
			}
		}
		string abs = new string (ab);
		return abs;
	}

	public void PatternToDict(){
		if (gh.dictionary.ContainsKey(gh.noOfPat)) {
			gh.dictionary [gh.noOfPat] = PatternToString ();
		} else {
			gh.dictionary.Add (gh.noOfPat, PatternToString ());
		}
		foreach(GameObject pt in patternTile){
			pt.GetComponent<Image> ().color = Color.black;
		}
	}

	public void ActiveSceneMake(){
		sceneMake.SetActive (true);
	}

	public void ActiveSceneEmpty(){
		sceneEmpty.SetActive (true);
	}

	public void DeActiveSceneMake(){
		sceneMake.SetActive (false);
	}

	public void DeActiveSceneEmpty(){
		sceneEmpty.SetActive (false);
	}
}
