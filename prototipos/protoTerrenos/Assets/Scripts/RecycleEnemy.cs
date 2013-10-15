using UnityEngine;
using System.Collections;

public class RecycleEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{
			if (gameObject.transform.position.z < Statics.Player.transform.position.z)
			{
				Destroy(gameObject);
			}
		}
	}
}
