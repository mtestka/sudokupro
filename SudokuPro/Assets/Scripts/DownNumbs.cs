using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DownNumbs : MonoBehaviour {

    // Use this for initialization
    private string no;

	void Start () {
            no = GetComponentInChildren<Text>().text;
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener(ChooseNumb);
        if (Application.loadedLevel == 1)
            GetComponentInChildren<Text>().font = GameObject.FindObjectOfType<Generate>().GetComponent<Generate>().fontForAll;
        else
            GetComponentInChildren<Text>().font = GameObject.FindObjectOfType<Generator4x4>().GetComponent<Generator4x4>().fontForAll;
            GetComponentInChildren<Text>().color = Color.white;
            GetComponentInChildren<Text>().fontSize = 80;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChooseNumb()
    {
        foreach(FieldSc fs in GameObject.FindObjectsOfType<FieldSc>())
        {
            if (fs.selected)
            {
                fs.gameObject.GetComponentInChildren<Text>().color = Color.red;
                fs.gameObject.GetComponentInChildren<Text>().text = no;
            }
        }
    }
}
