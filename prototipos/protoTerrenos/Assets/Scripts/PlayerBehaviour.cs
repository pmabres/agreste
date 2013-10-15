using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {	
	// Use this for initialization	
	public int HitPoints;
	void Awake () 
	{
		Statics.Player = gameObject;
	}
	void Start()
	{
		HitPoints = 1;
	}
	// Update is called once per frame
	void FixedUpdate () 
	{		
		if (!Statics.Paused)
		{					
			Statics.Meters = gameObject.transform.position.z;
		}		
	}
}
