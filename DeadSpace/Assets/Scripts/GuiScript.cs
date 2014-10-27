using UnityEngine;
using System.Collections;

public class GuiScript: MonoBehaviour {

	public int currentValue;
	public GUIStyle style;

	public int currentPlayer = 0;

	public GameObject[] myPlayers;
	public playerScript[] myPlayersScripts;

	// Use this for initialization
	void Start () {
		myPlayersScripts = new playerScript[myPlayers.Length];

		for (int i = 0; i < myPlayers.Length; i++)
		{
			myPlayersScripts[i] = myPlayers[i].GetComponent<playerScript>();
			myPlayersScripts[i].playerNumber = i;
		}

	}

	void Update()
	{
		foreach (playerScript p in myPlayersScripts)
		{
			if(p.placed == false)
			{
				currentPlayer = p.playerNumber;
			}
		}
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.Label(new Rect(10, 10, 100, 50), "Dice Roll: " + currentValue, style);

		//modular design
		/*
		GUI.Label(new Rect (10, Screen.height - Screen.height/8, 100,100), "Player " + 
		          (myPlayersScripts[currentPlayer].playerNumber + 1) + ": " + 
		          myPlayersScripts[currentPlayer].health + " health, " + 
		          myPlayersScripts[currentPlayer].armor + " armor", style);
		          */

		//player 1
		GUI.Label(new Rect (100, (Screen.height - Screen.height/2) + 100, 100,100), "Player 1: " + 
		          myPlayersScripts[0].health + " health, " + 
		          myPlayersScripts[0].armor + " armor", style);
		//player 2
		GUI.Label(new Rect (100, (Screen.height - Screen.height/2) + 150, 100,100), "Player 2: " + 
		          myPlayersScripts[1].health + " health, " + 
		          myPlayersScripts[1].armor + " armor", style);
		//player 3
		GUI.Label(new Rect (100, (Screen.height - Screen.height/2) + 200, 100,100), "Player 3: " + 
		          myPlayersScripts[2].health + " health, " + 
		          myPlayersScripts[2].armor + " armor", style);
		//player 4
		GUI.Label(new Rect (100, (Screen.height - Screen.height/2) + 250, 100,100), "Player 4: " + 
		          myPlayersScripts[3].health + " health, " + 
		          myPlayersScripts[3].armor + " armor", style);
	}
}
