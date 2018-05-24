using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution(300, 480, false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToScene(int scene)
    {
        //consider using LoadSceneMode.Additive
        //Debug.Log(scene);
        //Application.LoadLevel(scene);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
