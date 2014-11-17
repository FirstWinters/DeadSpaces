using UnityEngine;
using System.Collections;

public class spaceDamageRand : MonoBehaviour {

	int rand;

	public enum enemy {none, pack, slasher, stalker, regenerator, twitcher, bench, health};
	public enemy myEnemy;
	bool on = false;
	public int currentPlayersOn = 0;

	public playerScript myPlayerScripty;

	public Material[] monsterMats;


	// Use this for initialization
	void Start () {

		}

	void OnTriggerEnter()
	{
		if(!on)
		{
			rand = Random.Range (1, 100);
			on = true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (rand >= 1 && rand <= 5) {
			//player space Pack
			myEnemy = enemy.twitcher;
		}
		if (rand >= 6 && rand <= 20) {
			//player space Pack
			myEnemy = enemy.regenerator;
		}
		if (rand >= 21 && rand <= 35) {
			//player space Pack
			myEnemy = enemy.stalker;
		}
		if (rand >= 36 && rand <= 55) {
			//player space Pack
			myEnemy = enemy.slasher;
		}
		if (rand >= 56 && rand <= 80) {
			//player space Pack
			myEnemy = enemy.pack;
		}
		if (rand >= 81 && rand <= 90) {
			//player space Pack
			myEnemy = enemy.bench;
			//armor+=5;
		}
		if (rand >= 91 && rand <= 100) {
			//player space Pack
			myEnemy = enemy.health;
		}
	}
	void Update(){
		if (myEnemy == enemy.pack) {
			renderer.material = monsterMats[0];
		}
		if (myEnemy == enemy.slasher) {
			renderer.material = monsterMats[1];
		}
		if (myEnemy == enemy.stalker) {
			renderer.material = monsterMats[2];
		}
		if (myEnemy == enemy.regenerator) {
			renderer.material = monsterMats[3];
		}
		if (myEnemy == enemy.twitcher) {
			renderer.material = monsterMats[4];
		}
		if (myEnemy == enemy.bench) {
			renderer.material = monsterMats[5];
		}
		if (myEnemy == enemy.health) {
			renderer.material = monsterMats[6];
		}
	}

	public int GetDamage()
	{
		if (rand >= 1 && rand <= 5) {

			myEnemy = enemy.twitcher;
			//damage
			if (myPlayerScripty.myCharacter == playerScript.charClass2.eng)
			{
				return 50;
			}
			else {
				return 75;
			}
			
		}
		if (rand >= 6 && rand <= 20) {
			//player space Pack
			myEnemy = enemy.regenerator;
			if (myPlayerScripty.myCharacter == playerScript.charClass2.sol)
			{
				return 15;
			}
			else{
				return 25;
			}
		}
		if (rand >= 21 && rand <= 35) {
			//player space Pack
			myEnemy = enemy.stalker;
			//damage
			if (myPlayerScripty.myCharacter == playerScript.charClass2.sci)
			{
				return 15;
			}
			else{
				return 20;
			}
		}
		if (rand >= 36 && rand <= 55) {
			//player space Pack
			myEnemy = enemy.slasher;
			if (myPlayerScripty.myCharacter == playerScript.charClass2.civ)
			{
				return 10;
			}
			else{
				return 15;
			}
		}
		if (rand >= 56 && rand <= 80) {
			//player space Pack
			myEnemy = enemy.pack;
			//damage
			return 10;
		}
		if (rand >= 81 && rand <= 90) {
			//player space Pack
			myEnemy = enemy.bench;
			//armor+=5;
			return 0;
		}
		if (rand >= 91 && rand <= 100) {
			//player space Pack
			myEnemy = enemy.health;
			//playerHealth+=35;
			return -35;
		}
		else{
			return 0;
		}
	}
	public int GetArmor()
	{
		if (rand >= 81 && rand <= 90) {
			//player space Pack
			myEnemy = enemy.bench;
			//armor+=5;
			return 5;
		}
		else{
			return 0;
		}
	}
}
