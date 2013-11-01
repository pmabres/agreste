using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionsBehaviour : MonoBehaviour {
	List<int> ListMissions = new List<int>();
	List<string> AuxMission= new List<string>();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 3; i++) {
			int selected = Mathf.FloorToInt(Random.Range((float)Constants.SecMission.Min,(float)Constants.SecMission.Max));
			int Mts = 0;//Random.Range((Statics.Level * 100)/(5 * Statics.Level), (Statics.Level*100));
			int Enem = 0;//Random.Range((Statics.Level * 100)/(5 * Statics.Level), (Statics.Level*100));
			if(selected == (int) Constants.SecMission.CantMts)
			{
				AuxMission.Insert(1,"Recorrer " + Mts + " Mts.");
				ListMissions.Insert(1,Mts);
				Debug.Log ("1");
			}
			else if(selected == (int) Constants.SecMission.CantEnem)
			{
				AuxMission.Insert(2,"Embestir " + PlayerPrefs.GetInt("M2") + " Enemigos");
				ListMissions.Insert(2,selected);
				Debug.Log ("2");
			}
			else if(selected ==(int) Constants.SecMission.CantMtsSDN)
			{
				AuxMission.Insert(3,"Recorrer " + Mts + " Mts. sin recolectar Power Up's");
				ListMissions.Insert(3,Mts);
				Debug.Log ("3");
			}
			else if(selected ==(int) Constants.SecMission.CantMtsSPW)
			{
				AuxMission.Insert(3,"Recorrer " + Mts + " Mts. sin recibir daño");
				ListMissions.Insert(4,Mts);
				Debug.Log ("4");
			}
			else
			{
				i--;
			}
		}
		
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{
//			if(Statics.Meters > ListMissions.FindIndex(1))
//			{
		//		AuxMission.RemoveAt(ListMissions.FindIndex(1));
	//		}
		}
	}
}
