using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	GameObject player;
	//GameObject terrain;
	GameObject terrain2;	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Constants.TAG_PLAYER);
		Statics.terrain = new Terrains[6];
		for (int i = 0; i < Statics.terrain.Length; i++) 
		{
			Statics.terrain[i] = new Terrains();	
		}
		CreateTerrains();	
		
	}
	
	// Update is called once per frame
	void Update () {	
		if(player.transform.localPosition.z >(Statics.terrain[4].Field.transform.localPosition.z + Statics.terrain[4].Field.transform.localScale.z /2))
		{
			
			DestroyTerrain(3);
			DestroyTerrain(4);
			DestroyTerrain(5);	
			AddTerrainIndex(3);			
			CreateTerrain(0);
			CreateTerrain(1);
			CreateTerrain(2);
		}
		if(player.transform.localPosition.x >(Statics.terrain[4].Field.transform.localPosition.x + Statics.terrain[4].Field.transform.localScale.x / 2))
		{
				
			DestroyTerrain(3);
			DestroyTerrain(0);	
			AddTerrainIndex(-1);	
			CreateTerrain(5);
			CreateTerrain(2);
			
		}
		else if(player.transform.localPosition.x <(Statics.terrain[4].Field.transform.localPosition.x - Statics.terrain[4].Field.transform.localScale.x / 2))
		{
			
			DestroyTerrain(2);
			DestroyTerrain(5);
			AddTerrainIndex(1);
			CreateTerrain(0);
			CreateTerrain(3);			
		}
	}
	void AddTerrainIndex(int idx)
	{
		for (int i = 0; i < Statics.terrain.Length; i++) 
		{
			if (Statics.terrain[i].Field != null && i + idx < Statics.terrain.Length && i + idx >= 0)
			{
				Statics.terrain[i + idx].Field = Statics.terrain[i].Field;
			}
		}
	}
	void CreateTerrains()
	{					
		Statics.terrain[4].Field = Statics.Instantiate(Constants.TAG_TERRAIN, new Vector3(player.transform.position.x,0,player.transform.position.z), gameObject.transform);
		
		Statics.terrain[3].PositionChange = new Vector3(-Statics.terrain[4].Field.transform.localScale.x,0,0);		
		Statics.terrain[3].Field = Statics.Instantiate(Constants.TAG_TERRAIN, Statics.terrain[4].Field.transform.position + Statics.terrain[3].PositionChange, gameObject.transform);
		
		Statics.terrain[5].PositionChange = new Vector3(Statics.terrain[4].Field.transform.localScale.x,0,0);
		Statics.terrain[5].Field = Statics.Instantiate(Constants.TAG_TERRAIN, Statics.terrain[4].Field.transform.position + Statics.terrain[5].PositionChange, gameObject.transform);
		
		Statics.terrain[0].PositionChange = new Vector3(-Statics.terrain[4].Field.transform.localScale.x,0,Statics.terrain[4].Field.transform.localScale.z);
		Statics.terrain[0].Field = Statics.Instantiate(	Constants.TAG_TERRAIN, Statics.terrain[4].Field.transform.position  + Statics.terrain[0].PositionChange, gameObject.transform);
		
		Statics.terrain[2].PositionChange = new Vector3(Statics.terrain[4].Field.transform.localScale.x,0,Statics.terrain[4].Field.transform.localScale.z);
		Statics.terrain[2].Field = Statics.Instantiate(Constants.TAG_TERRAIN, Statics.terrain[4].Field.transform.position + Statics.terrain[2].PositionChange, gameObject.transform);
		 
		Statics.terrain[1].PositionChange = new Vector3(0,0,Statics.terrain[4].Field.transform.localScale.z);
		Statics.terrain[1].Field = Statics.Instantiate(Constants.TAG_TERRAIN, Statics.terrain[4].Field.transform.position + Statics.terrain[1].PositionChange, gameObject.transform);
	}
	void CreateTerrain(int i)
	{
//		Vector3 dimension = new Vector3();
//		if (Statics.terrain[4] != null )
//		{
//			dimension = Statics.terrain[4].transform.localScale;
//		}
		Statics.terrain[i].Field = Statics.Instantiate(Constants.TAG_TERRAIN, Statics.terrain[4].Field.transform.position + Statics.terrain[i].PositionChange,gameObject.transform);		
	}
	void DestroyTerrain(int i)
	{
		//for (int i = 0; i < Statics.terrain.Length; i++) 
		//{
			
			GameObject.Destroy(Statics.terrain[i].Field);
			//Statics.terrain[i].Field = null;
			
		//}
	}
}
