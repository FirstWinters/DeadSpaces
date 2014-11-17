using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	//Player variables
	public int health = 150;
	public int playerNumber;
	public int armor = 0;
	public enum charClass2 {civ, eng, sci, sol}
	public charClass2 myCharacter;

	public GameObject GUIObj;
	GuiScript GameManager;

	public GameObject HealthBar;

	//enum jobs {

	public bool placed = false;

	void Start()
	{
		GameManager = GUIObj.GetComponent<GuiScript>();
	}

	void Update()
	{
		SetHealthBar ();
	}

	void SetHealthBar()
	{
		float barheight = health/150f;
		HealthBar.transform.localScale = new Vector3(HealthBar.transform.localScale.x, HealthBar.transform.localScale.y, barheight);
		float barmissing = ((1-barheight)/2);
		HealthBar.gameObject.transform.localPosition = new Vector3(0, 0, 0 - (barmissing));
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Square"){

			c.GetComponent<spaceDamageRand>().myPlayerScripty = this.GetComponent<playerScript>();

			if(placed == true)
			{
				if (c.GetComponent<spaceDamageRand>().myEnemy == spaceDamageRand.enemy.bench)
				{
					armor += c.GetComponent<spaceDamageRand>().GetArmor();
				}
				else
				{
					//if the damage is negative, deal it
					if ((c.GetComponent<spaceDamageRand>().GetDamage() - armor) > 0)
					{
						//deal negative damage
						health -= (c.GetComponent<spaceDamageRand>().GetDamage() - armor);
					}
					//if its supposed to add health, do so.
					else if (c.GetComponent<spaceDamageRand>().GetDamage() == -35)
					{
						//deal "health" damage
						health -= (c.GetComponent<spaceDamageRand>().GetDamage() - armor);
					}
				}
				if (c.GetComponent<spaceDamageRand>().currentPlayersOn == 0)
				{
					this.transform.position = c.transform.position;
					c.GetComponent<spaceDamageRand>().currentPlayersOn++;
				}
				else if (c.GetComponent<spaceDamageRand>().currentPlayersOn == 1)
				{
					this.transform.position = c.transform.position + new Vector3(0,0,.25f);
					c.GetComponent<spaceDamageRand>().currentPlayersOn++;
				}
				else if (c.GetComponent<spaceDamageRand>().currentPlayersOn == 2)
				{
					this.transform.position = c.transform.position + new Vector3(0,0,-.25f);
					c.GetComponent<spaceDamageRand>().currentPlayersOn++;
				}
				else if (c.GetComponent<spaceDamageRand>().currentPlayersOn == 3)
				{
					this.transform.position = c.transform.position + new Vector3(0,0,-.5f);
					c.GetComponent<spaceDamageRand>().currentPlayersOn++;
				}
				SwitchTurn();
			}
			if (health <= 0)
			{
				health = 0;
				print ("Player " + playerNumber + " has been murdered by zombies.");
				SwitchTurn ();
				Destroy(this.gameObject);
			}

		}

	}
	void SwitchTurn()
	{
		if(GameManager.whoseTurn == 4)
		{
			GameManager.whoseTurn = 1;
		}
		else
		{
			GameManager.whoseTurn++;
		}
	}
	void OnTriggerExit(Collider c)
	{
		if (c.tag == "Square"){
			c.GetComponent<spaceDamageRand>().currentPlayersOn--;
		}
	}
}
