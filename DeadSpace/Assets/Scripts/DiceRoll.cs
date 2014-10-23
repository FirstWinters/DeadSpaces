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
}
