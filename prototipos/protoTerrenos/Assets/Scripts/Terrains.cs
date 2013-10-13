using UnityEngine;
using System.Collections;

public class TerrainList
{
	GameObject gTerrains;	
	public TerrainList()
	{		
		gTerrains = new GameObject();		
		gTerrains.AddComponent<Terrains>();		
		gTerrains.name = "TerrainList";
		gTerrains.tag = "TerrainList";
	}	
}

public class TerrainsProperties
{
	public Vector3 PositionChange {get;set;}
	public GameObject Field {get;set;}
}
public class Terrains:MonoBehaviour
{	
	private TerrainsProperties[] terrain;
	private GameObject player;
	
	public Terrains()
	{		
	}
	public void SetCurrentTerrain()
	{
		Statics.CurrentTerrain = terrain[4].Field;
	}
	void Start () {
		player = GameObject.FindGameObjectWithTag(Constants.TAG_PLAYER);
		terrain = new TerrainsProperties[6];
		for (int i = 0; i < terrain.Length; i++) 
		{
			terrain[i] = new TerrainsProperties();	
		}
		CreateTerrains();	
		SetCurrentTerrain();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{							
			if(player.transform.localPosition.z >(terrain[4].Field.transform.localPosition.z + terrain[4].Field.transform.localScale.z /2))
			{
				
				DestroyTerrain(3);
				DestroyTerrain(4);
				DestroyTerrain(5);	
				AddTerrainIndex(3);			
				CreateTerrain(0);
				CreateTerrain(1);
				CreateTerrain(2);
				AsignName();
				SetCurrentTerrain();
			}
			if(player.transform.localPosition.x >(terrain[4].Field.transform.localPosition.x + terrain[4].Field.transform.localScale.x / 2))
			{
					
				DestroyTerrain(3);
				DestroyTerrain(0);	
				AddTerrainIndex(-1);	
				CreateTerrain(5);
				CreateTerrain(2);
				AsignName();
				SetCurrentTerrain();
				
			}
			else if(player.transform.localPosition.x <(terrain[4].Field.transform.localPosition.x - terrain[4].Field.transform.localScale.x / 2))
			{
				DestroyTerrain(2);
				DestroyTerrain(5);
				AddTerrainIndex(1);
				
				CreateTerrain(0);
				CreateTerrain(3);			
	
				AsignName();
				SetCurrentTerrain();
			}
		}
	}
	void AsignName()
	{
		for (int i = 0; i < terrain.Length; i++) 
		{
			terrain[i].Field.name =i.ToString();	
		}
	}
	void AddTerrainIndex(int idx)
	{
		int a=0;
		int b=0;
		int c=0;
		if (idx >0)
		{			
			a=terrain.Length-1;
			b=-1;
			c=-1;
		}
		else
		{
			a=0;
			b=terrain.Length;
			c=1;
		}
		int d=-1;
		for (int i = a; i != b; i+=c) 
		{
			if (terrain[i].Field != null && i + idx < terrain.Length && i + idx >= 0 && d != i)	
			{								
				if (terrain[i + idx].Field == null) d=i + idx; else d=-1;
				terrain[i + idx].Field = terrain[i].Field;
			}
			
		}
	}
	void CreateTerrains()
	{					
		terrain[4].Field = Statics.Instantiate(Constants.TAG_TERRAIN, new Vector3(player.transform.position.x,0,player.transform.position.z), gameObject.transform);
		
		terrain[3].PositionChange = new Vector3(-terrain[4].Field.transform.localScale.x,0,0);		
		terrain[3].Field = Statics.Instantiate(Constants.TAG_TERRAIN, terrain[4].Field.transform.position + terrain[3].PositionChange, gameObject.transform);
		
		terrain[5].PositionChange = new Vector3(terrain[4].Field.transform.localScale.x,0,0);
		terrain[5].Field = Statics.Instantiate(Constants.TAG_TERRAIN, terrain[4].Field.transform.position + terrain[5].PositionChange, gameObject.transform);
		
		terrain[0].PositionChange = new Vector3(-terrain[4].Field.transform.localScale.x,0,terrain[4].Field.transform.localScale.z);
		terrain[0].Field = Statics.Instantiate(	Constants.TAG_TERRAIN, terrain[4].Field.transform.position  + terrain[0].PositionChange, gameObject.transform);
		
		terrain[2].PositionChange = new Vector3(terrain[4].Field.transform.localScale.x,0,terrain[4].Field.transform.localScale.z);
		terrain[2].Field = Statics.Instantiate(Constants.TAG_TERRAIN, terrain[4].Field.transform.position + terrain[2].PositionChange, gameObject.transform);
		 
		terrain[1].PositionChange = new Vector3(0,0,terrain[4].Field.transform.localScale.z);
		terrain[1].Field = Statics.Instantiate(Constants.TAG_TERRAIN, terrain[4].Field.transform.position + terrain[1].PositionChange, gameObject.transform);
		GenerateEnvironment();
	}
	void CreateTerrain(int i)
	{
		terrain[i].Field = Statics.Instantiate(Constants.TAG_TERRAIN, terrain[4].Field.transform.position + terrain[i].PositionChange,gameObject.transform);		
		GenerateEnvironment(i);
	}
	void DestroyTerrain(int i)
	{
		GameObject.Destroy(terrain[i].Field);
		terrain[i].Field = null;	
	}
	void GenerateEnvironment()
	{
		GenerateEnvironment(0);
		GenerateEnvironment(1);
		GenerateEnvironment(2);
		GenerateEnvironment(3);
		GenerateEnvironment(4);
		GenerateEnvironment(5);
	}
	void GenerateEnvironment(int i)
	{
		for (int b=1;b<Statics.TreesPerTerrain;b++)
		{
			int x =  Mathf.FloorToInt(Random.Range(terrain[i].Field.transform.position.x-terrain[i].Field.transform.localScale.x/2,terrain[i].Field.transform.position.x+terrain[i].Field.transform.localScale.x/2));
			int z =  Mathf.FloorToInt(Random.Range(terrain[i].Field.transform.position.z-terrain[i].Field.transform.localScale.z/2,terrain[i].Field.transform.position.z+terrain[i].Field.transform.localScale.z/2));
			Statics.Instantiate(Constants.NAME_TREES,new Vector3(x,0,z),terrain[i].Field.transform);	
		}
		
	}
}