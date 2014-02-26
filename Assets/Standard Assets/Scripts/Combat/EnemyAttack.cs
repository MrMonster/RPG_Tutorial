using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public GameObject target;
	public float attackTimer;
	public float coolDown;
	
	// Use this for initialization
	void Start () 
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		target = go;


		attackTimer = 0;
		coolDown = 2.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(attackTimer > 0)
			attackTimer -= Time.deltaTime;
		
		if(attackTimer < 0)
			attackTimer = 0;
		
		
		if(attackTimer == 0)
		{
			Attack();
			attackTimer = coolDown;
		}
	}
	
	private void Attack()
	{
		float distance = Vector3.Distance (target.transform.position, transform.position);
		
		Vector3 dir = (target.transform.position - transform.position).normalized;
		
		float direction = Vector3.Dot (dir, transform.forward);
		
		//Debug.Log ("Enemy" + direction);
		
		if(distance < 3.0f)
		{
			if(direction > 0.2)
			{
				PlayerAttack pa = (PlayerAttack)target.GetComponent("PlayerAttack");
				
				if(pa.defending == false)
				{
					Debug.Log ("enemy attack");
					PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
					ph.AdjustHealth (-10);
				}
			}
		}
	}
}
