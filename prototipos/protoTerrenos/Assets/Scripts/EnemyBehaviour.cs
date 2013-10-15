using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public int Damage;
	public float Speed;
	bool hitted=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{			
			gameObject.transform.position = gameObject.transform.position + new Vector3(0,0,-Speed);			
		}
	}
	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == Constants.TAG_PLAYER && !hitted)
        {			
            collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints -= Damage;
			hitted=true;
        }
    }
	
}
