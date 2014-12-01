using UnityEngine;
using System.Collections;

public class GuiScript: MonoBehaviour {

	//Set in SideTrigger
	public int currentValue;
	public GUIStyle style;
	public GUIStyle infoStyle;
	public GUIStyle enemyStyle;

	public int currentPlayer = 0;
	public int whoseTurn = 1;

	public GameObject[] myPlayers;
	public playerScript[] myPlayersScripts;

	public GameObject myBlock;

	public bool RollActive;
	public bool ReRollActive;

	public Font deadFont;

	public enum charClass {civ, eng, sci, sol}
	charClass myCharacter = new charClass();
	charClass p1 = new charClass();
	charClass p2 = new charClass();
	charClass p3 = new charClass();
	charClass p4 = new charClass();
	
	bool showStart = true;
	public bool showGame = false;

	// Use this for initialization
	void Start () {

		infoStyle.fontSize = 20;
		infoStyle.normal.textColor = Color.white;
		infoStyle.alignment = TextAnchor.MiddleCenter;
		infoStyle.font = deadFont;

		enemyStyle.normal.textColor = Color.white;
		enemyStyle.font = deadFont;

		myPlayersScripts = new playerScript[myPlayers.Length];

		for (int i = 0; i < myPlayers.Length; i++)
		{
			myPlayersScripts[i] = myPlayers[i].GetComponent<playerScript>();
			myPlayersScripts[i].playerNumber = i + 1;
		}

	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
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



		//modular design
		/*
		GUI.Label(new Rect (10, Screen.height - Screen.height/8, 100,100), "Player " + 
		          (myPlayersScripts[currentPlayer].playerNumber + 1) + ": " + 
		          myPlayersScripts[currentPlayer].health + " health, " + 
		          myPlayersScripts[currentPlayer].armor + " armor", style);
		          */
		if (showStart)
		{
			GUI.Label (new Rect (450, 10, 100, 50), "Choose your character!", infoStyle);
			if (GUI.Button (new Rect (100, 125, 100, 50), "Civilian")) {
				myCharacter = charClass.civ;
			}

			GUI.Box(new Rect(150,100,1000,325),"");

			if (myCharacter == charClass.civ) {

				GUI.Label(new Rect(500,100,150,150),"Civilian: \nCivilians take 5 points less damage to slashers.",infoStyle);
				//if (GUI.Button (new Rect (500, 100, 150, 50), "Choose Civilian")) {
				//do choose Civilian
				//}
			}
			
			if (GUI.Button (new Rect (100, 200, 100, 50), "Engineer")) {
				myCharacter = charClass.eng;
			}
			
			if (myCharacter == charClass.eng) {

				GUI.Label(new Rect(500,100,150,150),"Engineer: \nEngineers take 25 points less damage to twitchers.",infoStyle);
				//if (GUI.Button (new Rect (500, 200, 150, 50), "Choose Engineer")) {
				//do choose Engineer
				//}
			}
			
			if (GUI.Button (new Rect (100, 275, 100, 50), "Scientist")) {
				myCharacter = charClass.sci;
			}
			
			if (myCharacter == charClass.sci) {

				GUI.Label(new Rect(500,100,150,150),"Scientist: \nScientists take 5 points less damage to stalkers.",infoStyle);
				//if (GUI.Button (new Rect (500, 300, 150, 50), "Choose Scientist")) {
				//do choose Scientist
				//}
			}
			
			if (GUI.Button (new Rect (100, 350, 100, 50), "Soldier")) {
				myCharacter = charClass.sol;
			}
			
			if (myCharacter == charClass.sol) {

				GUI.Label(new Rect(500,100,150,150),"Soldier: \nSoldiers take 10 points less damage to generators.",infoStyle);
				//if (GUI.Button (new Rect (500, 400, 150, 50), "Choose Soldier")) {
				//do choose Soldier
				//}
			}
			//GUI.Label(new Rect(525,700,100,50),"Player 1: Civilian");
			GUI.Box (new Rect (10, 450, 150, 250), "Player 1 Select");
			if (GUI.Button (new Rect (35, 475, 100, 50), "Civilian")) {
				p1 = charClass.civ;
			}
			if (GUI.Button (new Rect (35, 525, 100, 50), "Engineer")) {
				p1 = charClass.eng;
			}
			if (GUI.Button (new Rect (35, 575, 100, 50), "Scientist")) {
				p1 = charClass.sci;
			}
			if (GUI.Button (new Rect (35, 625, 100, 50), "Soldier")) {
				p1 = charClass.sol;
			}
			if(p1 == charClass.civ){
				GUI.Label(new Rect (35,675,100,50), "Player 1: Civilian");
			}
			if(p1 == charClass.eng){
				GUI.Label(new Rect (35,675,150,50), "Player 1: Engineer");
			}
			if(p1 == charClass.sci){
				GUI.Label(new Rect (35,675,150,50), "Player 1: Scientist");
			}
			if(p1 == charClass.sol){
				GUI.Label(new Rect (35,675,100,50), "Player 1: Soldier");
			}
			
			
			GUI.Box (new Rect (160, 450, 150, 250), "Player 2 Select");
			if (GUI.Button (new Rect (185, 475, 100, 50), "Civilian")) {
				p2 = charClass.civ;
			}
			if (GUI.Button (new Rect (185, 525, 100, 50), "Engineer")) {
				p2 = charClass.eng;
			}
			if (GUI.Button (new Rect (185, 575, 100, 50), "Scientist")) {
				p2 = charClass.sci;
			}
			if (GUI.Button (new Rect (185, 625, 100, 50), "Soldier")) {
				p2 = charClass.sol;
			}
			if(p2 == charClass.civ){
				GUI.Label(new Rect (185,675,100,50), "Player 2: Civilian");
			}
			if(p2 == charClass.eng){
				GUI.Label(new Rect (185,675,150,50), "Player 2: Engineer");
			}
			if(p2 == charClass.sci){
				GUI.Label(new Rect (185,675,150,50), "Player 2: Scientist");
			}
			if(p2 == charClass.sol){
				GUI.Label(new Rect (185,675,100,50), "Player 2: Soldier");
			}
			
			GUI.Box (new Rect (310, 450, 150, 250), "Player 3 Select");
			if (GUI.Button (new Rect (335, 475, 100, 50), "Civilian")) {
				p3 = charClass.civ;
			}
			if (GUI.Button (new Rect (335, 525, 100, 50), "Engineer")) {
				p3 = charClass.eng;
			}
			if (GUI.Button (new Rect (335, 575, 100, 50), "Scientist")) {
				p3 = charClass.sci;
			}
			if (GUI.Button (new Rect (335, 625, 100, 50), "Soldier")) {
				p3 = charClass.sol;
			}
			if(p3 == charClass.civ){
				GUI.Label(new Rect (335,675,100,50), "Player 3: Civilian");
			}
			if(p3 == charClass.eng){
				GUI.Label(new Rect (335,675,150,50), "Player 3: Engineer");
			}
			if(p3 == charClass.sci){
				GUI.Label(new Rect (335,675,150,50), "Player 3: Scientist");
			}
			if(p3 == charClass.sol){
				GUI.Label(new Rect (335,675,100,50), "Player 3: Soldier");
			}
			
			GUI.Box (new Rect (460, 450, 150, 250), "Player 4 Select");
			if (GUI.Button (new Rect (485, 475, 100, 50), "Civilian")) {
				p4 = charClass.civ;
			}
			if (GUI.Button (new Rect (485, 525, 100, 50), "Engineer")) {
				p4 = charClass.eng;
			}
			if (GUI.Button (new Rect (485, 575, 100, 50), "Scientist")) {
				p4 = charClass.sci;
			}
			if (GUI.Button (new Rect (485, 625, 100, 50), "Soldier")) {
				p4 = charClass.sol;
			}
			if(p4 == charClass.civ){
				GUI.Label(new Rect (485,675,100,50), "Player 4: Civilian");
			}
			if(p4 == charClass.eng){
				GUI.Label(new Rect (485,675,150,50), "Player 4: Engineer");
			}
			if(p4 == charClass.sci){
				GUI.Label(new Rect (485,675,150,50), "Player 4: Scientist");
			}
			if(p4 == charClass.sol){
				GUI.Label(new Rect (485,675,100,50), "Player 4: Soldier");
			}
			if (GUI.Button(new Rect(700, 500, 250, 100), "Start"))
			{
				showStart = false;
				showGame = true;
				myBlock.SetActive(false);
				
				//apply char classes
				setChoices (p1, 0);
				setChoices (p2, 1);
				setChoices (p3, 2);
				setChoices (p4, 3);
			}
		}
		if (showGame)
		{
			GUI.Box(new Rect(10,500,500,250),"");
			GUI.Label(new Rect(12,501,150,250),"Enemy Damage Guide:\nTwitchers: 75pts.\nRegenterators: 25pts.\nStalkers: 20pts.\nSlashers: 15pts.\nPack: 5pts.\nBench: +5 armor.\nHealth: +35 HP.", enemyStyle);

			//Dice Roll text
			GUI.Label(new Rect(Screen.width/2, Screen.height/2 + Screen.height/3, 100, 50), "Dice Roll: " + currentValue, style);
			//Telling who's turn it is text
			GUI.Label(new Rect(Screen.width/2,Screen.height/2 + Screen.height/5,100,50), "It's Player " + whoseTurn + "'s Turn", style);
			//End Turn button
			if(GUI.Button(new Rect(Screen.width/2 + Screen.width/8 ,Screen.height/2 + Screen.height/4,100,150), "SKIP TURN"))
			{
				SwitchTurn();
			}

		//player 1
			GUI.Label(new Rect (200, (Screen.height - Screen.height/3) + Screen.height/16, 100,100), "Player 1: " + 
		          myPlayersScripts[0].health + " health, " + 
		          myPlayersScripts[0].armor + " armor, " + p1.ToString(), style);
		//player 2
			GUI.Label(new Rect (200, (Screen.height - Screen.height/3) + Screen.height/8, 100,100), "Player 2: " + 
		          myPlayersScripts[1].health + " health, " + 
		          myPlayersScripts[1].armor + " armor, " + p2.ToString (), style);
		//player 3
			GUI.Label(new Rect (200, (Screen.height - Screen.height/3) + Screen.height/8 + Screen.height/16, 100,100), "Player 3: " + 
		          myPlayersScripts[2].health + " health, " + 
			      myPlayersScripts[2].armor + " armor, " + p3.ToString(), style);
		//player 4
			GUI.Label(new Rect (200, (Screen.height - Screen.height/3) + Screen.height/4, 100,100), "Player 4: " + 
		          myPlayersScripts[3].health + " health, " + 
			      myPlayersScripts[3].armor + " armor, " + p4.ToString(), style);
		}
	}

	void setChoices(charClass c, int player)
	{
		if (c == charClass.civ)
		{
			myPlayersScripts[player].myCharacter = playerScript.charClass2.civ;
		}
		if (c == charClass.eng)
		{
			myPlayersScripts[player].myCharacter = playerScript.charClass2.eng;
		}
		if (c == charClass.sci)
		{
			myPlayersScripts[player].myCharacter = playerScript.charClass2.sci;
		}
		if (c == charClass.sol)
		{
			myPlayersScripts[player].myCharacter = playerScript.charClass2.sol;
		}
	}
	public void SwitchTurn()
	{
		if(whoseTurn == 4)
		{
			whoseTurn = 1;
		}
		else
		{
			whoseTurn++;
		}
	}
}
