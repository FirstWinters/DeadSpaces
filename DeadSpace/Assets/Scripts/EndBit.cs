using UnityEngine;
using System.Collections;

public class EndBit : MonoBehaviour {

	int rand;
	int playerWin;
	bool won = false;

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
			won = true;
			playerWin = c.GetComponent<playerScript>().playerNumber;
			StartCoroutine("ReloadScene");
		}
		else
		{
			print ("Choose better paths next time!");
		}
	}

	IEnumerator ReloadScene(int p)
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel(0);
	}

	void OnGUI()
	{
		if(won)
		{
			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "Player " + playerWin + " WINS!");
		}
	}

}
