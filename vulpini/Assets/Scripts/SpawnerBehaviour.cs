using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerBehaviour : MonoBehaviour {
	public float SpawnTimer=0.2f;
	public float SpawnPowerTimer=1;
	public float SpawnEnemyLastTime=0;
	public float SpawnPowerLastTime=0;
	int Selected;
	float [,] Enemy = new float [(int)Constants.EnemiesNames.Max,7];
	float [,] Powers = new float[(int)Constants.PowerNames.Max,7];
	List<int> ListEnem = new List<int>();
	List<int> ListPower = new List<int>();
	
	// Use this for initialization
	void Start () 
	{
		#region Tabla de probabilidad de aparicion enemigos/nivel
		//Enemy A
		//Enemi [Enemigo, Nivel]
		Enemy[0,0] = 1;
		Enemy[0,1] = 1;
		Enemy[0,2] = 0.75f;
		Enemy[0,3] = 0.5f;
		Enemy[0,4] = 0.25f;
		Enemy[0,5] = 0;
		Enemy[0,6] = 0;
		
		//Enemy B
		Enemy[1,0] = 0;
		Enemy[1,1] = 0.25f;
		Enemy[1,2] = 0.5f;
		Enemy[1,3] = 0.75f;
		Enemy[1,4] = 0.25f;
		Enemy[1,5] = 0;
		Enemy[1,6] = 0;
		
		//Enemy C
		Enemy[2,0] = 0;
		Enemy[2,1] = 0.5f;
		Enemy[2,2] = 0.75f;
		Enemy[2,3] = 1;
		Enemy[2,4] = 0.75f;
		Enemy[2,5] = 0.5f;
		Enemy[2,6] = 0.5f;
		
		//Enemy D
		Enemy[3,0] = 1;
		Enemy[3,1] = 0;
		Enemy[3,2] = 0;
		Enemy[3,3] = 0.5f;
		Enemy[3,4] = 0.75f;
		Enemy[3,5] = 1;
		Enemy[3,6] = 1;
		
		//Enemy E
		Enemy[4,0] = 0;
		Enemy[4,1] = 0;
		Enemy[4,2] = 0;
		Enemy[4,3] = 0.25f;
		Enemy[4,4] = 0.5f;
		Enemy[4,5] = 0.75f;
		Enemy[4,6] = 1;
		#endregion
		
		#region Tabla de probabilidad de aparicion PowerUps/Nivel
		//Salud
		Powers[0,0] = 0;
		Powers[0,1] = 0.75f;
		Powers[0,2] = 1;
		Powers[0,3] = 0.5f;
		Powers[0,4] = 1;
		Powers[0,5] = 0.5f;
		Powers[0,6] = 0.25f;
		
		//Speed
		Powers[1,0] = 0.25f;
		Powers[1,1] = 0.5f;
		Powers[1,2] = 0.25f;
		Powers[1,3] = 0.75f;
		Powers[1,4] = 0.75f;
		Powers[1,5] = 1;
		Powers[1,6] = 1;
		
		//Attack
		Powers[2,0] = 0.5f;
		Powers[2,1] = 0.5f;
		Powers[2,2] = 0.5f;
		Powers[2,3] = 1;
		Powers[2,4] = 0.5f;
		Powers[2,5] = 0.5f;
		Powers[2,6] = 0.75f;
		
		//Free
		Powers[3,0] = 1;
		Powers[3,1] = 0.75f;
		Powers[3,2] = 1;
		Powers[3,3] = 0.5f;
		Powers[3,4] = 1;
		Powers[3,5] = 0.5f;
		Powers[3,6] = 0.25f;
		#endregion
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!Statics.Paused)
		{
			SpawnEnemyLastTime += Time.deltaTime;
			SpawnPowerLastTime += Time.deltaTime;
			
			//Random Entre 0 y 1 para limitar la lista de enemigos y PowerUps
			float prob = (float) Random.Range(0.0f,1.0f);
			ListEnem.Clear();
			ListPower.Clear();
			
			#region Spawner Enemigos
			
			if (SpawnEnemyLastTime >= SpawnTimer)
			{
				//Se verifica si se recogio el power up de camino libre"
				if(!Statics.FreeRoad)
				{
					SpawnEnemyLastTime = 0;
					
					string EnemyName = null;
					
					//Se filtra por probabilidad
					for (int i = 0; i < (int)Constants.EnemiesNames.Max; i++) {
						
						if (prob <= Enemy[i,Statics.CurrentLevel-1]) 
						{
							ListEnem.Add(i);
						}						
					}
					GameObject child = null;
					//Se hace un random entre los enemigos en la lista
					Selected = Mathf.FloorToInt(Random.Range(0,(int) ListEnem.Count));
					if(ListEnem.Count>0)
						Selected = ListEnem[Selected];
					
					if (Selected == (int) Constants.EnemiesNames.NinoPalo)
					{
						EnemyName = "NinoPalo";
						//Debug.Log("NiñoPalo");						
					}
					else if (Selected == (int) Constants.EnemiesNames.NinoGomera)
					{
						EnemyName = "NinoGomera";
						child = Statics.Instantiate("Aura");
						child.GetComponent<AuraBehaviour>().speed = 1;
						//Debug.Log("NiñoGomera");
					}
					else if (Selected == (int) Constants.EnemiesNames.Cazador)
					{
						EnemyName = "Cazador";
						//Debug.Log("CazadorMach");
					}
					else if (Selected == (int) Constants.EnemiesNames.CazadorRifle)
					{
						EnemyName = "CazadorRifle";
						child = Statics.Instantiate("Aura");
						child.transform.localScale = new Vector3(30,1,30); // aumento la escala del aura del adulto
						child.GetComponent<AuraBehaviour>().speed = 0.7f;
						//Debug.Log("CazadorRif");
					}
					else if (Selected == (int) Constants.EnemiesNames.Perro)
					{
						EnemyName = "Perro";
						//Debug.Log("Perro");
					}
					
					if (EnemyName!=null)
					{
						
						gameObject.transform.position = new Vector3(Random.Range(Statics.Player.transform.position.x - 50,Statics.Player.transform.position.x + 50),
																	gameObject.transform.position.y,
																	Random.Range(Statics.Player.transform.position.z + 50,Statics.Player.transform.position.z + 150));
						GameObject enem = Statics.Instantiate(EnemyName,gameObject.transform.position,GameObject.FindGameObjectWithTag(Constants.TAG_ENEMIES).transform);
						enem.GetComponent<EnemyBehaviour>().EnemyType = Selected;
						if (child != null) 
						{
							child.transform.position = new Vector3(gameObject.transform.position.x,0.2f,gameObject.transform.position.z);
							child.transform.parent = enem.transform;							
						}
					}
				}
			}
			#endregion
				
			#region Spawner Power Up's
			if (SpawnPowerLastTime >= SpawnPowerTimer)
			{
				if(Statics.CountPowers < Constants.MAX_POWER_VIEW)
				{
					SpawnPowerLastTime = 0;
					string PowerName = null;
					
					for (int i = 0; i < (int) Constants.PowerNames.Max; i++) {
						if(prob <= Powers[i,Statics.CurrentLevel-1])
						{
							ListPower.Add(i);
						}
					}
					
					if(ListPower.Count != 0)
					{
						Selected = Mathf.FloorToInt(Random.Range(0,(int) ListPower.Count));
						Selected = ListPower[Selected];
						
						if (Selected == (int)Constants.PowerNames.Heal) 
						{
							PowerName = "Heal";
							//Debug.Log("Heal");
						}
						else if (Selected == (int)Constants.PowerNames.Speed) 
						{
							PowerName = "Speed";
							//Debug.Log("Speed");
						}
						else if (Selected == (int)Constants.PowerNames.Attack) 
						{
							PowerName = "Attack";
							//Debug.Log("Attack");
						}
						else if (Selected == (int)Constants.PowerNames.Free) 
						{
							PowerName = "Free";
							//Debug.Log("Free");
						}
						
						if (PowerName != null)
						{
							gameObject.transform.position= new Vector3(Random.Range(Statics.Player.transform.position.x - 50,Statics.Player.transform.position.x + 50),
																			gameObject.transform.position.y + 1.1f,
																			Random.Range(Statics.Player.transform.position.z + 50,Statics.Player.transform.position.z + 150));
							Statics.Instantiate("Power",gameObject.transform.position,GameObject.FindGameObjectWithTag(Constants.TAG_POWER).transform, PowerName );
							Statics.CountPowers ++;
						}
					}
				}
			}
			#endregion
		}
	}
}