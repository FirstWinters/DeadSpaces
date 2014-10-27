using UnityEngine;
using System.Collections;

public class DiceRoll : MonoBehaviour {

	private bool trigged = false;

	// Use this for initialization
	void Start () {
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
		if(GUI.Button(new Rect(200,10,100,50), "Roll")){
			gameObject.rigidbody.useGravity = true;
		}
		if(GUI.Button(new Rect(200,50,100,50), "Re-Roll")){
			gameObject.transform.localPosition = new Vector3(2.806149f,-1.866022f,6.140697f);
			trigged = false;
			gameObject.rigidbody.useGravity=false;
			Start();
			FixedUpdate();
		}
	}
}
