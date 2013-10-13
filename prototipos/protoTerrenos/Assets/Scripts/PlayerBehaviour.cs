using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	public bool isPaused;
	// Use this for initialization
	void Awake () 
	{
		Statics.Player = gameObject;
	}
	void Start()
	{
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		isPaused = Statics.Paused;
		if (!Statics.Paused)
		{		
			
		}
	}
}
