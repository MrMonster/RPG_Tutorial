using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;
	public int minDistance;
	
	private Transform myTransform;
	
	void Awake()
	{
		myTransform = transform;
	}
		
	// Use this for initialization
	void Start () 
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		target = go.transform;

		myTransform.renderer.material.color = Color.blue;

	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.DrawLine (target.position, myTransform.position, Color.yellow);
		
		//Look at target
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		
		if(Vector3.Distance (target.position, myTransform.position) < maxDistance && Vector3.Distance (target.position, myTransform.position) > minDistance)
		{
			//Move to target
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}

		//restricting rotation to the Y axis
		Vector3 eulerAngles = myTransform.rotation.eulerAngles;
		eulerAngles = new Vector3(0, eulerAngles.y, 0);
		myTransform.rotation = Quaternion. Euler(eulerAngles);
	}
}
