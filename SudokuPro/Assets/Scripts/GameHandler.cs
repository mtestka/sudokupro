using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class GameHandler : MonoBehaviour {

	public int noOfPat = 0;

	public Dictionary<int, string> dictionary;

	void Awake()
	{
		DontDestroyOnLoad(this);

		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
		dictionary = new Dictionary<int, string> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToScene(int scene){
		SceneManager.LoadScene(scene);
	}

	public void ActiveGameObject(string name){
		GameObject.Find (name).SetActive (true);
	}

	public void DeActiveGameObject(string name){
		GameObject.Find (name).SetActive (false);
	}
}
