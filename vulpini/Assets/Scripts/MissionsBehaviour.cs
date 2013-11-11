using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MissionsBehaviour : MonoBehaviour {	
	
	// Use this for initialization
	public MissionsBehaviour()
	{
	}
	void Start () 
	{
		gameObject.GetComponent<TextMesh>().text = "";
		CreateMissions();
		SetText();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		CheckActive();		
		if (!Statics.Paused)
		{			
			CheckMissions();
		}
	}
	
	private void SetText()
	{
		for (int i = 0; i < Statics.lstMissions.Count; i++) 
		{
			if (Statics.lstMissions[i].Active)
			{
				string text = Statics.lstMissions[i].Descripcion;
				if (Statics.lstMissions[i].Completada)
				{
					text = "<color=#B8B8B8>" + text + ". OK! </color>";
				}
				gameObject.GetComponent<TextMesh>().text += text +  Environment.NewLine;
			}
		}
	}
	#region Mission Creation
	private void CreateMissions()
	{		
		Statics.lstMissions.Add(new Misiones("Sobrevivir 500 Metros","500",10,Constants.Tipos.Alcanzar,false,false));		
		Statics.lstMissions.Add(new Misiones("Viajar 100 Metros en Lateral","100",10,Constants.Tipos.AlcanzarY,false,false));
		Statics.lstMissions.Add(new Misiones("Recoger 3 PowerUps","3",10,Constants.Tipos.PowerUps,false,false));
		
		Statics.lstMissions.Add(new Misiones("Sobrevivir 1000 Metros","1000",10,Constants.Tipos.Alcanzar,false,false));
		Statics.lstMissions.Add(new Misiones("Sobrevivir 500 Metros sin PowerUps","500",10,Constants.Tipos.AlcanzarNoPowerUps,false,false));
		Statics.lstMissions.Add(new Misiones("Embestir 2 Enemigos","2",10,Constants.Tipos.Estampar,false,false));
		
		Statics.lstMissions.Add(new Misiones("Morir antes de los 1000 Metros","1000",10,Constants.Tipos.Morir,false,false));
		Statics.lstMissions.Add(new Misiones("Sobrevivir 1000 Metros sin PowerUps","1000",10,Constants.Tipos.AlcanzarNoPowerUps,false,false));
		Statics.lstMissions.Add(new Misiones("Sobrevivir 200 Metros con 1 Vida","200",10,Constants.Tipos.AlcanzarVida,false,false));
		
		Statics.lstMissions.Add(new Misiones("Sobrevivir Entre 1000 y 3000 Metros","1000,3000",10,Constants.Tipos.SobrevivirRango,false,false));
		Statics.lstMissions.Add(new Misiones("Embestir 5 Enemigos","5",10,Constants.Tipos.Estampar,false,false));
		Statics.lstMissions.Add(new Misiones("Sobrevivir 2000 metros sin agarrar PowerUps","2000",10,Constants.Tipos.AlcanzarNoPowerUps,false,false));
		if (Statics.CompletedMissions != null && Statics.CompletedMissions != "")
		{
			string[] completed = Statics.CompletedMissions.Split(',');
			foreach (string c in completed)
			{
				if (c != "" && int.Parse(c) < Statics.lstMissions.Count)
				{
					Statics.lstMissions[int.Parse (c)].Completada = true;
				}
			}
			int i;
			for (i=Statics.lstMissions.Count-1;i>=0;i--)
			{
				if (i > 1 &&
					Statics.lstMissions[i].Completada && 
					Statics.lstMissions[i-1].Completada && 
					Statics.lstMissions[i-2].Completada &&
					i + 1 % 3 == 0)
				{
					break;
				}
			}
			if (i==0)
			{
				Statics.lstMissions[0].Active = true;
				Statics.lstMissions[1].Active = true;
				Statics.lstMissions[2].Active = true;	
			}
			else
			{
				Statics.lstMissions[i + 1].Active = true;
				Statics.lstMissions[i + 2].Active = true;
				Statics.lstMissions[i + 3].Active = true;
			}
		}
		else
		{
			Statics.lstMissions[0].Active = true;
			Statics.lstMissions[1].Active = true;
			Statics.lstMissions[2].Active = true;			
		}
	}
	#endregion
	
	#region Mission Check
	
	private void CheckActive()
	{		
		int i;		
		for (i=Statics.lstMissions.Count-1;i>=0;i--)
		{
			if (Statics.lstMissions[i].Active)
			{				
				break;
			}			
		}
		if (Statics.lstMissions[i].Completada &&
			Statics.lstMissions[i-1].Completada &&
			Statics.lstMissions[i-2].Completada)
		{
			Statics.lstMissions[i].Active = false;
			Statics.lstMissions[i-1].Active = false;
			Statics.lstMissions[i-2].Active = false;
			gameObject.GetComponent<TextMesh>().text = "";
			Statics.lstMissions[i+1].Active = true;
			Statics.lstMissions[i+2].Active = true;
			Statics.lstMissions[i+3].Active = true;
			SetText();
		}
	}
	private void CheckMissions()
	{
		for (int i = 0; i < Statics.lstMissions.Count; i++) 
		{
			if (!Statics.lstMissions[i].Completada && Statics.lstMissions[i].Active)
			{
				if (Statics.lstMissions[i].Tipo == Constants.Tipos.Alcanzar)
				{
					CheckGoal(i,Statics.lstMissions[i].Tipo,Statics.Meters.ToString());
				}
				else if (Statics.lstMissions[i].Tipo == Constants.Tipos.AlcanzarNoPowerUps && Statics.PowerUpsHitted == 0)
				{
					CheckGoal(i,Statics.lstMissions[i].Tipo,(Statics.Meters).ToString());
				}
				else if (Statics.lstMissions[i].Tipo == Constants.Tipos.AlcanzarVida)
				{
					CheckGoal(i,Statics.lstMissions[i].Tipo,Statics.MetersOneHit.ToString());
				}
				else if (Statics.lstMissions[i].Tipo == Constants.Tipos.AlcanzarY)
				{
					CheckGoal(i,Statics.lstMissions[i].Tipo,Statics.MetersSide.ToString());
				}
				else if (Statics.lstMissions[i].Tipo == Constants.Tipos.Estampar)
				{
					CheckGoal(i,Statics.lstMissions[i].Tipo,Statics.SmashedEnemies.ToString());
				}
				else if (Statics.lstMissions[i].Tipo ==  Constants.Tipos.Morir && Statics.Player.GetComponent<PlayerBehaviour>().HitPoints <= 0)
				{
					CheckGoal(i,Statics.lstMissions[i].Tipo,Statics.Meters.ToString ());
				}
				else if (Statics.lstMissions[i].Tipo == Constants.Tipos.PowerUps)
				{
					CheckGoal(i,Statics.lstMissions[i].Tipo,Statics.PowerUpsHitted.ToString());
				}
				else if (Statics.lstMissions[i].Tipo == Constants.Tipos.SobrevivirRango && Statics.Player.GetComponent<PlayerBehaviour>().HitPoints <= 0)
				{
					CheckGoal(i,Statics.lstMissions[i].Tipo,Statics.Meters.ToString());
				}
			}
		}
	}
	private void CheckGoal(int i,Constants.Tipos t, string valor)
	{		
		if (t == Constants.Tipos.SobrevivirRango) // si se trata de un rango entonces busco por rango
		{
			if (int.Parse(Statics.lstMissions[i].Valores.Substring(0,Statics.lstMissions[i].Valores.IndexOf(','))) <= int.Parse(valor) &&
				int.Parse(Statics.lstMissions[i].Valores.Substring(Statics.lstMissions[i].Valores.IndexOf(',')+1)) >= int.Parse(valor) )
			{
				CompletarMision(i);
			}
		}
		else if (t == Constants.Tipos.Morir)
		{
			if (int.Parse(Statics.lstMissions[i].Valores) >= int.Parse(valor))
			{
				CompletarMision(i);
			}
		}
		else
		{
			if (int.Parse(Statics.lstMissions[i].Valores) <= int.Parse(valor))
			{
				CompletarMision(i);
			}	
		}	
	}
	private void CompletarMision(int id)
	{
		if (Statics.lstMissions != null && Statics.lstMissions.Count != 0 && Statics.lstMissions[id] != null )
		{
			if (!Statics.lstMissions[id].Completada)
			{
				Statics.lstMissions[id].Completada = true;
				Statics.Paws += Statics.lstMissions[id].Recompensa;
				Statics.CompletedMissions += id + ",";
				gameObject.GetComponent<TextMesh>().text = "";
				SetText();
			}
		}
	}
	#endregion
}
