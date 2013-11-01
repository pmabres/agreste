using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public int Damage;
	public float Speed;
	bool hitted=false;
	float ImpulseH = 0;
		
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
				gameObject.transform.position = gameObject.transform.position - new Vector3(0 + ImpulseH,0,Constants.SPEED_NINO_PALO);			
			}
			else if (EnemiType == (int) Constants.EnemiesNames.NinoGomera)
			{
				gameObject.transform.position = gameObject.transform.position - new Vector3(0+ ImpulseH,0,Constants.SPEED_NINO_GOMERA);			
			}
			else if (EnemiType == (int) Constants.EnemiesNames.Cazador)
			{
				gameObject.transform.position = gameObject.transform.position - new Vector3(0+ ImpulseH,0,Constants.SPEED_CAZADOR);			
			}
			else if (EnemiType == (int) Constants.EnemiesNames.CazadorRifle)
			{
				gameObject.transform.position = gameObject.transform.position - new Vector3(0 + ImpulseH,0,Constants.SPEED_CAZADOR_RIFLE);			
			}
			else if (EnemiType == (int) Constants.EnemiesNames.Perro)
			{
				if(gameObject.transform.position.x < Statics.Player.transform.position.x)
				{
					gameObject.transform.position = gameObject.transform.position - new Vector3(-0.05f + ImpulseH,0,Constants.SPEED_PERRO);		
				}
				else if(gameObject.transform.position.x > Statics.Player.transform.position.x)
				{
					gameObject.transform.position = gameObject.transform.position - new Vector3(0.05f + ImpulseH,0,Constants.SPEED_PERRO);		
				}
			}
			if(ImpulseH !=0)
			{
				if(ImpulseH < 0)
				{
					ImpulseH += 0.2f;
					if (ImpulseH > 0) ImpulseH = 0;
				}
				else if(ImpulseH >0)
				{
					ImpulseH -= 0.2f;
					if (ImpulseH < 0) ImpulseH = 0;
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == Constants.TAG_PLAYER && !collider.gameObject.GetComponent<PlayerBehaviour>().Hitted)
        {		
			if(gameObject.transform.position.x < collider.gameObject.transform.position.x)
				collider.gameObject.GetComponent<PlayerBehaviour>().ImpulseH = 3;
			else if (gameObject.transform.position.x > collider.gameObject.transform.position.x)
				collider.gameObject.GetComponent<PlayerBehaviour>().ImpulseH = -3;
				
			if(collider.gameObject.GetComponent<PlayerBehaviour>().Attack)
			{
				Debug.Log("salvado");
			}
			else
			{
				if(EnemiType == (int) Constants.EnemiesNames.NinoPalo)
				{					
					collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints -= Constants.DAMAGE_NINO_PALO;
				}
				else if (EnemiType == (int) Constants.EnemiesNames.NinoGomera)
				{
					collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints -= Constants.DAMAGE_NINO_GOMERA;
				}
				else if (EnemiType == (int) Constants.EnemiesNames.Cazador)
				{
					collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints -= Constants.DAMAGE_CAZADOR;
				}
				else if (EnemiType == (int) Constants.EnemiesNames.CazadorRifle)
				{
					collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints -= Constants.DAMAGE_CAZADOR_RIFLE;
				}
				else if (EnemiType == (int) Constants.EnemiesNames.Perro)
				{
            		collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints -= Constants.DAMAGE_PERRO;
				}
				collider.gameObject.GetComponent<PlayerBehaviour>().Hitted=true;
			}
        }
		else if(collider.gameObject.tag == Constants.TAG_TREE)
		{
			if(gameObject.transform.position.x < collider.gameObject.transform.position.x)
				ImpulseH = 1;
			else if (gameObject.transform.position.x > collider.gameObject.transform.position.x)
				ImpulseH = -1;
		}	
    }
	
}
