using UnityEngine;
using System.Collections;

public class DetectObjects : MonoBehaviour {

	Ray myRay;

	Vector3 direction;
	RaycastHit hit;

	Vector3 pos;

	bool held = true;

	// Update is called once per frame
	void Update () 
	{
		pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		direction = transform.forward;
		myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Input.GetKeyDown(KeyCode.Mouse0) && !held)
		{
			held = true;
		}
		else if(Input.GetKeyDown(KeyCode.Mouse0) && held)
		{
			held = false;
		}

		if (Physics.Raycast (myRay, out hit, 200.0f))
		{
			/*
			if(Input.GetKeyDown(KeyCode.Mouse0) && hit.transform.tag == "Player" && !held)
			{
				hit.transform.position = myRay.origin + myRay.direction * 10;

			}
			else if(Input.GetKeyDown(KeyCode.Mouse0)  && hit.transform.tag == "Player" && held)
			{

			}
			*/

			if(hit.transform.tag == "Player" && !held)
			{
				hit.transform.position = myRay.origin + myRay.direction * 10;
				
			}
		}	
	}
	
}


