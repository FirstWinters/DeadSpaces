using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	//Player variables
	public int health = 150;
	public int playerNumber;
	public int armor = 0;


	bool placed = false;
	bool want = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Mouse0)){
			want = true;
			this.transform.position = new Vector3 (transform.position.x, transform.position.y, -5);
		}
		if (Input.GetKeyUp(KeyCode.Mouse0)){
			want = false;
			this.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		}

	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Square"){

			if(placed == false)
			{
				if (c.GetComponent<spaceDamageRand>().myEnemy == spaceDamageRand.enemy.bench)
				{
					armor += c.GetComponent<spaceDamageRand>().GetArmor();
				}
				else{
					health -= (c.GetComponent<spaceDamageRand>().GetDamage() - armor);
				}

				this.transform.position = c.transform.position;
				placed = true;
			}

			//do other square stuff

		}
	}
	void OnTriggerExit(Collider c)
	{
		placed = false;
	}
}
