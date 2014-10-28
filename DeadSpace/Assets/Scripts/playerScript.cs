using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	//Player variables
	public int health = 150;
	public int playerNumber;
	public int armor = 0;
	public enum charClass2 {civ, eng, sci, sol}
	public charClass2 myCharacter;

	//enum jobs {

	public bool placed = false;

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
				this.transform.position = c.transform.position;
			}
			if (health <= 0)
			{
				health = 0;
				print ("Player " + playerNumber + " has been murdered by zombies.");
				Destroy(this.gameObject);
			}

		}

	}
}
