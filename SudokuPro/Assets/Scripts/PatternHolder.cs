using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PatternHolder : MonoBehaviour {

	private GameHandler gh;
	public GameObject sceneGen, scenePat;

	// Use this for initialization
	void Start () {
		gh = GameObject.FindObjectOfType<GameHandler> ().GetComponent<GameHandler> ();
		if (gh.dictionary.ContainsKey ((int)Char.GetNumericValue ((char)gameObject.name [0]))) {
			Debug.Log ((int)Char.GetNumericValue ((char)gameObject.name [0]));
			gameObject.GetComponentInChildren<Text> ().text = "Pattern " + (char)gameObject.name [0];
		} else {
			gameObject.GetComponentInChildren<Text> ().text = "Empty Pattern";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gh.dictionary.ContainsKey ((int)Char.GetNumericValue ((char)gameObject.name [0]))) {
			gameObject.GetComponentInChildren<Text> ().text = "Pattern " + (char)gameObject.name [0];
		}
	}

	public void GivePatternName(){
		gh.noOfPat = (int)Char.GetNumericValue (gameObject.name[0]);
		sceneGen.SetActive (true);
		scenePat.SetActive (false);
	}
}
