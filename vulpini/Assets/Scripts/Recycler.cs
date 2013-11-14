using UnityEngine;
using System.Collections;

public class Recycler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{
			if (gameObject.transform.position.z < Statics.Player.transform.position.z - 15)
			{
				if(gameObject.tag == Constants.TAG_SPEED ||gameObject.tag == Constants.TAG_HEALTH || gameObject.tag == Constants.TAG_FREEROAD || gameObject.tag == Constants.TAG_ATTACK)
				{
					Statics.CountPowers -= 1;
				}
				Destroy(gameObject);
			}
		}
	}
}
