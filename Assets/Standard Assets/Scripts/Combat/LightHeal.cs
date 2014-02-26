using UnityEngine;
using System.Collections;

public class LightHeal : MonoBehaviour {
	public GameObject player;
	public float healTimer;
	public float coolDown;
	public int healAmount;

	// Use this for initialization
	void Start () 
	{
		healTimer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(healTimer > 0)
			healTimer -= Time.deltaTime;
		
		if(healTimer < 0)
			healTimer = 0;
		
		
		if(healTimer == 0)
		{
			Heal();
			healTimer = coolDown;
		}
	}
	
	private void Heal()
	{

		float distance = Vector3.Distance (player.transform.position, transform.position);
		
		//Debug.Log ("Heal Zone" + distance);
		
		if(distance < 13.0f)
		{
			PlayerHealth ph = (PlayerHealth)player.GetComponent("PlayerHealth");
			ph.AdjustHealth (healAmount);
		}
	}
}

