using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public int Damage;
	public float Speed;
	bool hitted=false;
	public int EnemiType {
		get;
		set;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{	
			if(EnemiType == (int) Constants.EnemiesNames.NinoPalo)
			{
				gameObject.transform.position = gameObject.transform.position + new Vector3(0,0,-Speed);			
			}
			else if (EnemiType == (int) Constants.EnemiesNames.NinoGomera)
			{
			}
			else if (EnemiType == (int) Constants.EnemiesNames.Cazador)
			{
			}
			else if (EnemiType == (int) Constants.EnemiesNames.CazadorRifle)
			{
			}
			else if (EnemiType == (int) Constants.EnemiesNames.Perro)
			{
			}
		}
	}
	
	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == Constants.TAG_PLAYER && !hitted)
        {			
			if(collider.gameObject.GetComponent<PlayerBehaviour>().Attack)
			{
				//Debug.Log("salvado");
			}
			else
			{
            	collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints -= Damage;
				hitted=true;
			}
        }
    }
	
}
