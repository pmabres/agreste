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
			if (gameObject.transform.position.z < Statics.Player.transform.position.z)
			{
				if(gameObject.tag == "Power")
				{
					Statics.CountPowers -= 1;
				}
				Destroy(gameObject);
			}
		}
	}
}
