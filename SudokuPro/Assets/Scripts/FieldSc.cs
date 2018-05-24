using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldSc : MonoBehaviour {

    public bool selected = false;

	// Use this for initialization
	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(MakeSelect);
        if (Application.loadedLevel == 1)
            GetComponentInChildren<Text>().font = GameObject.FindObjectOfType<Generate>().GetComponent<Generate>().fontForAll;
        else
            GetComponentInChildren<Text>().font = GameObject.FindObjectOfType<Generator4x4>().GetComponent<Generator4x4>().fontForAll;
        GetComponentInChildren<Text>().color = Color.white;
        GetComponentInChildren<Text>().fontSize = 80;
    }

    // Update is called once per frame
    void Update () {
        if (selected)
            GetComponent<Image>().color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1f));
        else
            GetComponent<Image>().color = Color.white;
    }

    public void MakeSelect()
    {
        if (GetComponentInChildren<Text>().color == Color.red || GetComponentInChildren<Text>().text == "")
        {
            foreach (FieldSc fs in GameObject.FindObjectsOfType<FieldSc>())
            {
                fs.selected = false;
            }
            selected = true;
        }
        else
        {
            foreach (FieldSc fs in GameObject.FindObjectsOfType<FieldSc>())
            {
                fs.selected = false;
            }
        }
    }
}
