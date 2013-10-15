
using UnityEngine;
using System.Collections;

public class MovementBehaviour : MonoBehaviour {	
	// Use this for initialization
	CharacterMotor motor;
	float AccelLimit = 0.3f;
	int maxSideSpeed = 24; // the actual speed its obtained multiplying for AccelLimit. EX: 0.3f * 24 = 8
	void Start () 
	{		
		motor = Statics.Player.GetComponent<CharacterMotor>();											
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{
			if (Statics.AccelerometerActive)
			{
				AccelerationDetect();
			}
			else
			{
				TouchDetect();
			}
		}
	}
	void AccelerationDetect()
	{
		float accelX = Input.acceleration.x;
		if (accelX >= AccelLimit)
		{
			 accelX = AccelLimit;
		}
		else if (accelX <= -AccelLimit)
		{
			accelX = -AccelLimit;
		}
		motor.SetVelocity(new Vector3(accelX*maxSideSpeed,motor.movement.velocity.y,motor.movement.velocity.z));
	}
	void TouchDetect()
	{
		if (Input.touchCount > 0 && Input.touchCount < 3)
		{
			
			float touch1=0;
			float touch2=0;
			touch1 = Input.GetTouch(0).position.x;			
			if (Input.touchCount>1) touch2 = Input.GetTouch(1).position.x;
			
			if (touch1 != 0 ^ touch2 != 0)
			{		
				if ((touch1<Screen.width*Constants.TOUCH_SCREEN_WIDTH_PROPORTION && touch1>0)||(touch2<Screen.width*Constants.TOUCH_SCREEN_WIDTH_PROPORTION && touch2>0)) // if the user press left go left
				{
					motor.SetVelocity(new Vector3(-AccelLimit*maxSideSpeed,motor.movement.velocity.y,motor.movement.velocity.z));
				}			
				if (touch1>Screen.width - Screen.width*Constants.TOUCH_SCREEN_WIDTH_PROPORTION ||touch2>Screen.width - Screen.width*Constants.TOUCH_SCREEN_WIDTH_PROPORTION ) // if the user press right go right
				{					
					motor.SetVelocity(new Vector3(AccelLimit*maxSideSpeed,motor.movement.velocity.y,motor.movement.velocity.z));
				}
			}
		}	
	}
}
