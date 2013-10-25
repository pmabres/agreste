using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerBehaviour : MonoBehaviour {
	public float SpawnTimer=0.2f;
	public float SpawnLastTime=0;
	float [,] Enemi = new float [(int)Constants.EnemiesNames.Max,7];
	List<int> ListEnem = new List<int>();
	
	// Use this for initialization
	void Start () 
	{
		//Enemy A
		//Enemi [Enemigo, Nivel]
		Enemi[0,0] = 1;
		Enemi[0,1] = 1;
		Enemi[0,2] = 0.75f;
		Enemi[0,3] = 0.5f;
		Enemi[0,4] = 0.25f;
		Enemi[0,5] = 0;
		Enemi[0,6] = 0;
		
		//Enemy B
		Enemi[1,0] = 0;
		Enemi[1,1] = 0.25f;
		Enemi[1,2] = 0.5f;
		Enemi[1,3] = 0.75f;
		Enemi[1,4] = 0.25f;
		Enemi[1,5] = 0;
		Enemi[1,6] = 0;
		
		//Enemy C
		Enemi[2,0] = 0;
		Enemi[2,1] = 0.5f;
		Enemi[2,2] = 0.75f;
		Enemi[2,3] = 1;
		Enemi[2,4] = 0.75f;
		Enemi[2,5] = 0.5f;
		Enemi[2,6] = 0.5f;
		
		//Enemy D
		Enemi[3,0] = 0;
		Enemi[3,1] = 0;
		Enemi[3,2] = 0;
		Enemi[3,3] = 0.5f;
		Enemi[3,4] = 0.75f;
		Enemi[3,5] = 1;
		Enemi[3,6] = 1;
		
		//Enemy E
		Enemi[4,0] = 0;
		Enemi[4,1] = 0;
		Enemi[4,2] = 0;
		Enemi[4,3] = 0.25f;
		Enemi[4,4] = 0.5f;
		Enemi[4,5] = 0.75f;
		Enemi[4,6] = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!Statics.Paused)
		{
			SpawnLastTime += Time.deltaTime;
			if (SpawnLastTime >= SpawnTimer)
			{
				
				SpawnLastTime = 0;
				
				string EnemyName = null;
				//Random Entre 0 y 1 para limitar la lista de enemigos
				float prob = (float) Random.Range(0.0f,1.0f);
				
				ListEnem.Clear();
			
				
				//Se filtra por probavilidad
				for (int i = 0; i < (int)Constants.EnemiesNames.Max; i++) {
					
					if (prob <= Enemi[i,Statics.CurrentLevel-1]) 
					{
						ListEnem.Add(i);
					}
				}
				
				//Se hace un random entre los enemigos en la lista
				int Selected = Mathf.FloorToInt(Random.Range(0,(int) ListEnem.Count));
				Selected = ListEnem[Selected];
				Debug.Log(Selected);
				
				if (Selected == (int) Constants.EnemiesNames.HunterA)
				{
					EnemyName = "HunterA";
					Debug.Log("HunterA");
				}
				else if (Selected == (int) Constants.EnemiesNames.HunterB)
				{
					EnemyName = "HunterA";
					Debug.Log("HunterB");
				}
				else if (Selected == (int) Constants.EnemiesNames.HunterC)
				{
					EnemyName = "HunterA";
					Debug.Log("HunterC");
				}
				else if (Selected == (int) Constants.EnemiesNames.HunterD)
				{
					EnemyName = "HunterA";
					Debug.Log("HunterD");
				}
				
				if (EnemyName!=null)
				{
					
					gameObject.transform.position = new Vector3(Random.Range(Statics.Player.transform.position.x - 50,Statics.Player.transform.position.x + 50),
																gameObject.transform.position.y,
																Random.Range(Statics.Player.transform.position.z + 50,Statics.Player.transform.position.z + 150));
					Statics.Instantiate(EnemyName,gameObject.transform.position,GameObject.FindGameObjectWithTag(Constants.TAG_ENEMIES).transform);
				}
			}
		}
	}
}