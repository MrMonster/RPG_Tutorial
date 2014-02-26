using UnityEngine;
using System.Collections;

public class Gu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.Box (new Rect(0,0,Screen.width,Screen.height),"hello");
	
		GUI.Button(new Rect(Screen.width / 3, Screen.height /2, Screen.width / 5, Screen.height / 8), "Play");
		
		
	}
	
}
