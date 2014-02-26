using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour {
	
	public List<Transform> targets;
	public Transform selectedTarget;
	
	private Transform myTransform;
	
	// Use this for initialization
	void Start () 
	{
		targets = new List<Transform>();
		selectedTarget = null;
		myTransform = transform;
		AddAllEnemies();
	}
	
	public void AddAllEnemies()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Enemy");
		
		foreach(GameObject enemy in go)
			AddTarget(enemy.transform);
	}
	
	public void AddTarget(Transform enemy)
	{
		targets.Add(enemy);
	}
	
	//Sorts the targets based on distance from player.
	private void SortTargetsByDistance()
	{
		targets.Sort(delegate(Transform t1, Transform t2) 
		{
			return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));
		});
	}
	
	private void TargetEnemy()
	{
		SortTargetsByDistance();
		selectedTarget = targets[0];
		/*if(selectedTarget == null)
		{
			SortTargetsByDistance();
			selectedTarget = targets[0];
		}
		else
		{
			int index = targets.IndexOf(selectedTarget);
			
			if(index < targets.Count - 1)
			{
				index++;
			}
			else
			{
				index = 0;
			}
			DeselectTarget ();
			selectedTarget = targets[index];
		}*/
		SelectTarget ();
	}
	
	private void SelectTarget()
	{
		selectedTarget.renderer.material.color = Color.red;
		
		PlayerAttack pa = (PlayerAttack)GetComponent("PlayerAttack");
		
		pa.target = selectedTarget.gameObject;
	}
	
	private void DeselectTarget()
	{
		selectedTarget.renderer.material.color = Color.blue;
		selectedTarget = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		EnemyHealth eh = (EnemyHealth)targets[0].GetComponent("EnemyHealth");

		if(Input.GetKeyDown(KeyCode.Tab))
		{
			TargetEnemy();

			eh = (EnemyHealth)targets[0].GetComponent("EnemyHealth");
			eh.isTargetted = true;

			for(int i = 0; i < targets.Count; i++)
			{
				if(targets[i] != selectedTarget)
				{
					EnemyHealth ehit = (EnemyHealth)targets[i].GetComponent("EnemyHealth");
					ehit.isTargetted = false;
				}
			}
		}

		if(eh.curHealth == 0)
		{
			DeselectTarget();
			targets.RemoveAt(0);
			eh.RemoveUnit();
		}
	}
}
