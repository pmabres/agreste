using UnityEngine;
using System.Collections;

public class MenuBehaviour : MonoBehaviour {
	
	GameObject menu;
	// Use this for initialization
	void Start () 
	{
		menu = GameObject.FindGameObjectWithTag("Menu");
	}	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if ((Input.touchCount>0 || Input.GetMouseButtonDown(0)) && Statics.Paused)
		{
			Statics.Paused = false;			
			menu.SetActive(false);
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && !Statics.Paused) 	   	
		{
			Statics.Paused = true;
			menu.SetActive(true);
		}	
		else if (Input.GetKeyDown(KeyCode.Escape) && Statics.Paused)
		{
			Application.Quit();
		}
	}
}
