using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternField : MonoBehaviour {

	public bool selected = false;

	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(MakeSelect);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void MakeSelect()
	{
		if (GetComponent<Image> ().color == Color.black)
			GetComponent<Image> ().color = Color.white;
		else
			GetComponent<Image> ().color = Color.black;
	}
}