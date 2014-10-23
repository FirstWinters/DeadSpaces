using UnityEngine;
using System.Collections;

public class GuiScript: MonoBehaviour {

	public int currentValue;
	public GUIStyle style;

	public int currentPlayer = 0;
	public int currentHealth = 0;

	public GameObject[] myPlayers;
	public playerScript[] myPlayersScripts;

	// Use this for initialization
	void Start () {
		myPlayersScripts = new playerScript[myPlayers.Length];

		for (int i = 0; i < myPlayers.Length; i++)
		{
			myPlayersScripts[i] = myPlayers[i].GetComponent<playerScript>();
		}

	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.Label(new Rect(10, 10, 100, 50), "Dice Roll: " + currentValue, style);

		GUI.Label(new Rect (10, Screen.height - Screen.height/8, 100,100), "Player " + 
		          myPlayersScripts[currentPlayer].playerNumber + ": " + 
		          myPlayersScripts[currentPlayer].health + " health, " + 
		          myPlayersScripts[currentPlayer].armor + " armor", style);
	}
}
