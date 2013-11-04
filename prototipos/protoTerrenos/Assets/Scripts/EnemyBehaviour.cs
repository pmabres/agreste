using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public int Damage;
	public float Speed;
	bool hitted=false;
	float ImpulseH = 0;
		
	public int EnemyType {
		get;
		set;
	}
	// Use this for initialization
	void Awake () 
	{
		if(EnemyType == (int) Constants.EnemiesNames.NinoPalo)
		{
			Speed = Constants.SPEED_NINO_PALO;
			Damage = Constants.DAMAGE_NINO_PALO;
		}
		else if (EnemyType == (int) Constants.EnemiesNames.NinoGomera)
		{
			Speed = Constants.SPEED_NINO_GOMERA;				
			Damage = Constants.DAMAGE_NINO_GOMERA;
		}
		else if (EnemyType == (int) Constants.EnemiesNames.Cazador)
		{
			Speed = Constants.SPEED_CAZADOR;				
			Damage = Constants.DAMAGE_CAZADOR;
		}
		else if (EnemyType == (int) Constants.EnemiesNames.CazadorRifle)
		{
			Speed = Constants.SPEED_CAZADOR_RIFLE;
			Damage = Constants.DAMAGE_CAZADOR_RIFLE;
		}
		else if (EnemyType == (int) Constants.EnemiesNames.Perro)
		{
			Speed = Constants.SPEED_PERRO;
			Damage = Constants.DAMAGE_PERRO;				
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{	
			ChasePlayer();
			gameObject.transform.position = gameObject.transform.position - new Vector3(0 + ImpulseH,0,Speed);
			if(ImpulseH !=0)
			{
				if(ImpulseH < 0)
				{
					//prueba para ver si lo hace smooth
					//ImpulseH = Mathf.SmoothStep(ImpulseH,0,Time.smoothDeltaTime);
					ImpulseH = Mathf.Lerp(ImpulseH,0,Time.smoothDeltaTime*10);					
					//ImpulseH += 0.2f;
					if (ImpulseH > 0) ImpulseH = 0;
				}
				else if(ImpulseH >0)
				{
					ImpulseH = Mathf.Lerp(ImpulseH,0,Time.smoothDeltaTime*10);
					//ImpulseH = Mathf.SmoothStep(ImpulseH,0,Time.smoothDeltaTime);
					//ImpulseH -= 0.2f;
					if (ImpulseH < 0) ImpulseH = 0;
				}
			}
		}
	}
	
	void ChasePlayer()
	{
		if (EnemyType == (int) Constants.EnemiesNames.Perro)
		{
			if(gameObject.transform.position.x < Statics.Player.transform.position.x)
			{
				gameObject.transform.position = gameObject.transform.position - new Vector3(-0.05f + ImpulseH,0,Speed);		
			}
			else if(gameObject.transform.position.x > Statics.Player.transform.position.x)
			{
				gameObject.transform.position = gameObject.transform.position - new Vector3(0.05f + ImpulseH,0,Speed);		
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
            	collider.gameObject.GetComponent<PlayerBehaviour>().HitPoints -= Damage;
				collider.gameObject.GetComponent<PlayerBehaviour>().Hitted=true;
				Statics.Hit.SetActive(true);
			}
        }
		else if(collider.gameObject.tag == Constants.TAG_TREE)
		{
			if(gameObject.transform.position.x < collider.gameObject.transform.position.x)
				ImpulseH = 0.5f;
			else if (gameObject.transform.position.x > collider.gameObject.transform.position.x)
				ImpulseH = -0.5f;
		}	
    }
	
}
