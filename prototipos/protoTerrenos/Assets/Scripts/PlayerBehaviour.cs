using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {	
	// Use this for initialization	
	public bool Attack = false;
	public float TimeAttack = 0;
	public float TimeFree = 0;
	public int HitPoints;
	
	void Awake () 
	{
		Statics.Player = gameObject;
	}
	void Start()
	{
		HitPoints = Statics.MaxHealth;
	}
	// Update is called once per frame
	void FixedUpdate () 
	{		
		if (!Statics.Paused)
		{					
			Statics.Meters = gameObject.transform.position.z;
			if(Attack)
			{
				TimeAttack += Time.deltaTime;
				if(TimeAttack>=Statics.TimeAttack)
				{Attack = false; TimeAttack=0;}
			}
			
			if(Statics.FreeRoad)
			{
				TimeFree += Time.deltaTime;
				if(TimeFree >= Statics.TimeFree)
				{Statics.FreeRoad = false; TimeFree=0;}
			}
		}		
	}
}
