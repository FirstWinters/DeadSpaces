﻿using UnityEngine;
using System.Collections;

public class DiceRoll : MonoBehaviour {

	private bool trigged = false;
	public GameObject GUIObj;
	GuiScript GameManager;

	public AudioSource DiceSound;

	// Use this for initialization
	void Start () {
		GameManager = GUIObj.GetComponent<GuiScript>();
		transform.eulerAngles = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
	}

	void OnTriggerEnter(Collider other)
	{
		trigged = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!trigged){
			rigidbody.AddTorque(Random.Range (1f,20f), Random.Range (1f,20f), Random.Range (1f,20f));
		}
		else
		{
			rigidbody.AddTorque(0,0,0);
		}
	}

	void OnGUI(){
		if(GameManager.showGame)
		{
			if(GameManager.RollActive == true)
			{
				if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 + Screen.height/4,100,50), "Roll")){
					DiceSound.Play();
					gameObject.rigidbody.useGravity = true;
					GameManager.RollActive = false;
				}
			}
			if(GameManager.ReRollActive == true)
			{
				if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 + Screen.height/4 + Screen.height/8,100,50), "Re-Roll")){
					gameObject.transform.localPosition = new Vector3(2.806149f,-1.866022f,6.140697f);
					trigged = false;
					gameObject.rigidbody.useGravity=false;
					Start();
					FixedUpdate();
					GameManager.RollActive = true;
					GameManager.ReRollActive = false;
				}
			}
		}
	}
}
