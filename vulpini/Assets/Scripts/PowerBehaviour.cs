using UnityEngine;
using System.Collections;

public class PowerBehaviour : MonoBehaviour {
	bool hitted=false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == Constants.TAG_PLAYER && !hitted)
        {			
			Statics.PowerUpsHitted ++;
			if (this.tag == "Heal") {
				if(collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints < Statics.MaxHealth)
					collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints += 1;
			}
			else if (this.tag == "Speed") {
				collider.gameObject.GetComponent<Avanzar>().Speed=true;
			}
			else if (this.tag == "Attack") {
				collider.gameObject.GetComponent<PlayerBehaviour>().Attack=true;
			}
			else if (this.tag == "FreeRoad") {
				Statics.FreeRoad = true;
			}
			Statics.CountPowers -= 1;
			hitted=true;
        }
    }
}
