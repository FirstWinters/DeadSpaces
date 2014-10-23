using UnityEngine;
using System.Collections;

public class SideTrigger : MonoBehaviour {

	Camera myCamera;
	public int DieValue;

	// Use this for initialization
	void Start () {
		myCamera = Camera.main;
	}
	
	// Update is called once per frame

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Ground"){
			myCamera.GetComponent<GuiScript>().currentValue = DieValue;
			//diceGameObject.rigidbody.velocity = new Vector3(0,0,0);
			//print("inside " + DieValue);
		}
		//Debug.Log(DieValue);
		
	}

	void Update () {
//		GameObject diceGameObject = GameObject.Find("Dice");
//		if(diceGameObject.rigidbody.velocity == new Vector3(0,0,0)){
//			Debug.Log("IT WORKED!");
//			diceGameObject.GetComponent<DiceValue>().currentValue = finalValue;
//		}
	}

//	void OnGUI () {
//		GUI.Label(new Rect(10, 10, 100, 50), "Dice Roll: " + DieValue, style);
//	}

}
