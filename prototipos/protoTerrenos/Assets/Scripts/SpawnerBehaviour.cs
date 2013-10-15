using UnityEngine;
using System.Collections;

public class SpawnerBehaviour : MonoBehaviour {
	public float SpawnTimer=0.2f;
	public float SpawnLastTime=0;
	// Use this for initialization
	void Start () 
	{
		
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
				int Selected = Mathf.FloorToInt(Random.Range((int) Constants.EnemiesNames.Min,(int) Constants.EnemiesNames.Max));
				if (Selected == (int) Constants.EnemiesNames.HunterA)
				{
					EnemyName = "HunterA";
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