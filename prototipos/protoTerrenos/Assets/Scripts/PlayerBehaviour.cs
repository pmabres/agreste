using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {	
	// Use this for initialization	
	public bool Attack = false;
	public float TimeAttack = 0;
	public float TimeFree = 0;
	public float TimeHit = 0;
	public bool Hitted = false;
	public int HitPoints;
	public float ImpulseH;
	
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
			Statics.Meters = (int) gameObject.transform.position.z;
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
			
			if(ImpulseH !=0)
			{
				if(ImpulseH < 0)
				{
					ImpulseH += 0.75f;
					if (ImpulseH > 0) ImpulseH = 0;
				}
				else if(ImpulseH >0)
				{
					ImpulseH -= 0.75f;
					if (ImpulseH < 0) ImpulseH = 0;
				}
			}
			
			if(Hitted)
			{
				TimeHit += Time.deltaTime;
				if(TimeHit >= 2000)
				{	
					Hitted=false;
					TimeHit =0 ;
				}
			}
		}		
	}
	void OnTriggerEnter(Collider collider)
    {
		if (collider.gameObject.tag == Constants.TAG_TREE)
		{
			gameObject.transform.position -= new Vector3 (0,0,0.75f);
			if(gameObject.transform.position.x < collider.gameObject.transform.position.x)
			{
				ImpulseH = -3;
			}
			else if (gameObject.transform.position.x > collider.gameObject.transform.position.x)
			{
				ImpulseH = 3;
			}
			
		}
	}
}
