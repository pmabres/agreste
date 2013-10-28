using UnityEngine;
using System.Collections;

public class Avanzar : MonoBehaviour 
{
	private CharacterMotor motor;
	public bool Speed = false;
	private float TimeSpeed =0;

	public bool corriendo=true;	
	// Use this for initialization
	void Start () 
	{
		motor = GetComponent<CharacterMotor>();
	}
	// Update is called once per frame
	void FixedUpdate () 
	{	
		if (!Statics.Paused)
		{						
			if(corriendo)
			{			
				
				if (Speed) {
					TimeSpeed += Time.deltaTime;
					if(TimeSpeed<Statics.MaxTimeSpeed){
						motor.movement.maxForwardSpeed += 0.8f;
						motor.movement.maxSidewaysSpeed += 0.5f;
						
						if(motor.movement.maxForwardSpeed > 20)
							motor.movement.maxForwardSpeed = 20;
					
						if(motor.movement.maxSidewaysSpeed > 20)
							motor.movement.maxSidewaysSpeed = 20;
					}
					else
					{
						TimeSpeed = 0;
						Speed =false;
					}
				}
				else
				{
					motor.movement.maxForwardSpeed += 0.4f;
					motor.movement.maxSidewaysSpeed += 0.2f;
					if(motor.movement.maxForwardSpeed > 10)
						motor.movement.maxForwardSpeed = 10;
				
					if(motor.movement.maxSidewaysSpeed > 10)
						motor.movement.maxSidewaysSpeed = 10;
				}
				motor.SetVelocity(new Vector3(motor.movement.velocity.x,motor.movement.velocity.y,motor.movement.maxForwardSpeed));
			}
		}
	}
}
