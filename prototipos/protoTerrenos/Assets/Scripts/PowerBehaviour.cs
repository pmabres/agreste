using UnityEngine;
using System.Collections;

public class PowerBehaviour : MonoBehaviour {
	bool hitted=false;
	// Use this for initialization
	void Start () {
		if (this.name == "Heal") {
			gameObject.GetComponent<Light>().color=Color.green;
		}
		else if (this.name == "Speed") {
			gameObject.GetComponent<Light>().color=Color.blue;
		}
		else if (this.name == "Attack") {
			gameObject.GetComponent<Light>().color=Color.red;
		}
		else if (this.name == "Free") {
			gameObject.GetComponent<Light>().color=Color.cyan;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == Constants.TAG_PLAYER && !hitted)
        {			
			if (this.name == "Heal") {
				if(collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints < Statics.MaxHealt)
					collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints += 1;
			}
			else if (this.name == "Speed") {
				collider.gameObject.GetComponent<Avanzar>().Speed=true;
			}
			else if (this.name == "Attack") {
				collider.gameObject.GetComponent<PlayerBehaviour>().Attack=true;
			}
			else if (this.name == "Free") {
				Statics.FreeRoad = true;
			}
			hitted=true;
        }
    }
}
