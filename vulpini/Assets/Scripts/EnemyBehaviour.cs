using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	public int Damage;
	public float Speed;	
	public float ImpulseH = 0;
	public int EnemyType {get;set;}
	public int Distance =0;
	// Use this for initialization
	void Start() 
	{
		if(EnemyType == (int) Constants.EnemiesNames.NinoMelee)
		{
			Speed = Constants.SPEED_NINO_RANGED;
			Damage = Constants.DAMAGE_NINO_MELEE;
			Distance = 15;
		}
		else if (EnemyType == (int) Constants.EnemiesNames.NinoRanged)
		{
			Speed = Constants.SPEED_NINO_MELEE;				
			Damage = Constants.DAMAGE_NINO_RANGED;
			Distance = 20;
		}
		else if (EnemyType == (int) Constants.EnemiesNames.CazadorMelee)
		{
			Speed = Constants.SPEED_CAZADOR_MELEE;				
			Damage = Constants.DAMAGE_CAZADOR_MELEE;
			Distance = 15;
		}
		else if (EnemyType == (int) Constants.EnemiesNames.CazadorRanged)
		{
			Speed = Constants.SPEED_CAZADOR_RANGED;
			Damage = Constants.DAMAGE_CAZADOR_RANGED;
			Distance = 25;
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
			//gameObject.transform.position = gameObject.transform.position - new Vector3(0 + ImpulseH,0,Speed);
			gameObject.transform.LookAt(Statics.Player.transform.position + new Vector3(0,0, 5));
			gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
			ImpulseH = Mathf.Lerp(ImpulseH,0,Time.smoothDeltaTime*10);

			if(Vector3.Distance(Statics.Player.transform.position,gameObject.transform.position)< Distance)
			{
				gameObject.GetComponent<Animator>().SetFloat("transition", Mathf.Lerp(gameObject.GetComponent<Animator>().GetFloat("transition"),1,Time.deltaTime*2));
			}
		}
	}
	public void Hit()
	{
		Statics.Player.GetComponent<PlayerBehaviour>().HitPoints -= Damage;
		Statics.Player.GetComponent<PlayerBehaviour>().Hitted=true;
		Statics.Hit.SetActive(true);
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
				collider.gameObject.GetComponent<PlayerBehaviour>().ImpulseH = 10;
			else if (gameObject.transform.position.x > collider.gameObject.transform.position.x)
				collider.gameObject.GetComponent<PlayerBehaviour>().ImpulseH = -10;
				
			if(collider.gameObject.GetComponent<PlayerBehaviour>().Attack)
			{
				Debug.Log("salvado");
				Statics.SmashedEnemies ++;
			}
			else
			{
            	Hit();
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
