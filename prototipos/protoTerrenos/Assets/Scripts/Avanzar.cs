using UnityEngine;
using System.Collections;

public class Avanzar : MonoBehaviour 
{
	private CharacterMotor motor;
	public bool corriendo=true;	
	// Use this for initialization
	void Start () 
	{
		motor = GetComponent<CharacterMotor>();
	}
	// Update is called once per frame
	void Update () 
	{		
		if(corriendo)
		{
			if(Time.deltaTime>=0.02)
			{
				motor.movement.maxForwardSpeed += 0.4f;
				motor.movement.maxSidewaysSpeed += 0.2f;
				
				if(motor.movement.maxForwardSpeed > 25)
					motor.movement.maxForwardSpeed = 25;
				
				if(motor.movement.maxSidewaysSpeed > 15)
					motor.movement.maxSidewaysSpeed = 15;
			}
			motor.SetVelocity(new Vector3(motor.movement.velocity.x,motor.movement.velocity.y,motor.movement.maxForwardSpeed));
		}
	}
}
