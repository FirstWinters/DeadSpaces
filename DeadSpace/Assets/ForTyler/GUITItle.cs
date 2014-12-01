using UnityEngine;
using System.Collections;

public class GUITItle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2, 100, 50), "Play")) {
			Application.LoadLevel(1);
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 50), "Credits")) {
			Application.LoadLevel(2);
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 100, 100, 50), "How To")) {
			Application.LoadLevel(3);
		}
	}
}
