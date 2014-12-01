using UnityEngine;
using System.Collections;

public class GUICredits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 200, 100, 50), "Back")) {
			Application.LoadLevel(0);
		}
	}
}
