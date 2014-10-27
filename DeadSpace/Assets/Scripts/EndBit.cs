using UnityEngine;
using System.Collections;

public class EndBit : MonoBehaviour {

	int rand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		print ("Time for the final zombie horde!");

		rand = Random.Range (0, 30);
		c.GetComponent<playerScript>().health -= rand;

		print ("You took " + rand + " damage!");


		if (c.GetComponent<playerScript>().health > 0)
		{
			//they win
			print ("You Survived!");
		}
		else
		{
			print ("Choose better paths next time!");
		}
	}

}
