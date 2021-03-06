using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
	
	public GameObject target;
	public float attackTimer;
	public float coolDown;
	public bool defending = false;

	
	// Use this for initialization
	void Start () 
	{
		attackTimer = 0;
		coolDown = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(attackTimer > 0)
			attackTimer -= Time.deltaTime;
		
		if(attackTimer < 0)
			attackTimer = 0;
		
		if(Input.GetKeyUp (KeyCode.Space))
		{
			if(attackTimer == 0)
			{
				gameObject.animation.Play ("Default Take");
				Attack();
				attackTimer = coolDown;
			}
		}
		
		if(Input.GetKeyUp (KeyCode.E))
		{
			Defend();
			defending = true;
		}
		else defending = false;
	}
	
	private void Attack()
	{
		float distance = Vector3.Distance (target.transform.position, transform.position);
		
		Vector3 dir = (target.transform.position - transform.position).normalized;
		
		float direction = Vector3.Dot (dir, transform.forward);
		
		Debug.Log (direction);
		
		if(distance < 2.5f)
		{
			if(direction > 0.8)
			{
				EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
				eh.AdjustHealth (-10);
			}
		}
	}

	private void Defend()
	{
		Vector3 dir = (target.transform.position - transform.position).normalized;
		
		float direction = Vector3.Dot (dir, transform.forward);


		transform.position += transform.forward * -2;
	}
	
}
