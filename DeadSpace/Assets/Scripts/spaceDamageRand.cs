using UnityEngine;
using System.Collections;

public class spaceDamageRand : MonoBehaviour {

	int rand;

	public enum enemy {none, pack, slasher, stalker, regenerator, twitcher, bench, health};
	public enemy myEnemy;

	Camera myCamera;
	bool on = false;


	// Use this for initialization
	void Start () {
		myCamera = Camera.main;
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
			renderer.material.color = Color.black;
		}
		if (myEnemy == enemy.slasher) {
			renderer.material.color = Color.blue;
		}
		if (myEnemy == enemy.stalker) {
			renderer.material.color = Color.cyan;
		}
		if (myEnemy == enemy.regenerator) {
			renderer.material.color = Color.green;
		}
		if (myEnemy == enemy.twitcher) {
			renderer.material.color = Color.magenta;
		}
		if (myEnemy == enemy.bench) {
			renderer.material.color = Color.red;
		}
		if (myEnemy == enemy.health) {
			renderer.material.color = Color.yellow;
		}
	}

	public int GetDamage()
	{
		if (rand >= 1 && rand <= 5) {
			//damage
			return 75;
			
		}
		if (rand >= 6 && rand <= 20) {
			//player space Pack
			myEnemy = enemy.regenerator;
			//damage
			return 25;
		}
		if (rand >= 21 && rand <= 35) {
			//player space Pack
			myEnemy = enemy.stalker;
			//damage
			return 20;
		}
		if (rand >= 36 && rand <= 55) {
			//player space Pack
			myEnemy = enemy.slasher;
			//damage
			return 15;
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
