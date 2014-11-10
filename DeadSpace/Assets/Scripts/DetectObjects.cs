using UnityEngine;
using System.Collections;

public class DetectObjects : MonoBehaviour {

	Ray myRay;
	
	RaycastHit hit;

	public bool held = false;

	GameObject heldObject;

	GuiScript myGUIScript;

	void Start()
	{
		myGUIScript = GetComponent<GuiScript>();
	}

	void Update()
	{
		//this.transform.LookAt(myGUIScript.myPlayers[myGUIScript.currentPlayer].transform);
	}
	// Update is called once per frame
	void LateUpdate () 
	{

		myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (myRay, out hit, 200.0f))
		{

			if (hit.transform.tag == "Player" && hit.transform.GetComponent<playerScript>().playerNumber == myGUIScript.whoseTurn)
			{
				if(Input.GetKeyDown(KeyCode.Mouse0) && !held)
				{
					held = true;
					heldObject = hit.transform.gameObject;
				}
				else if(Input.GetKeyUp(KeyCode.Mouse0) && held)
				{
					held = false;
				}


				//Debug.DrawRay (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.up * -100, Color.red);
				//print(hit.transform.name);

				/*
				if(held)
				{
					hit.transform.position = myRay.origin + myRay.direction * 5;
					Vector3 temp = hit.transform.position;
					temp.y = 5;
					hit.transform.position = temp;
					hit.transform.GetComponent<playerScript>().placed = false;
				}
				else if (!held)
		        {
					Vector3 temp = hit.transform.position;
					temp.y = 0;
					hit.transform.position = temp;
					hit.transform.GetComponent<playerScript>().placed = true;
				}
				*/
			}
		}

		if(held)
		{
			heldObject.transform.position = myRay.origin + myRay.direction * 5;
			Vector3 temp = heldObject.transform.position;
			temp.y = 5;
			heldObject.transform.position = temp;
			heldObject.transform.GetComponent<playerScript>().placed = false;
		}
		else if (!held)
		{
			if (heldObject != null)
			{
				Vector3 temp = heldObject.transform.position;
				temp.y = 0;
				heldObject.transform.position = temp;
				heldObject.transform.GetComponent<playerScript>().placed = true;
				heldObject = null;
			}
		}
	}
}


