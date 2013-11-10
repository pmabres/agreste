using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Misiones
{
	public string Descripcion {get;set;}
	public string Valores {get;set;}
	public Constants.Tipos  Tipo {get;set;}		
	public int Recompensa {get;set;}
	public bool Completada {get;set;}
	public bool Active {get;set;}
	public Misiones(string Descripcion, string Valores, int Recompensa,Constants.Tipos Tipo, bool Completada, bool Active)
	{
		this.Descripcion = Descripcion;
		this.Valores = Valores;		
		this.Recompensa = Recompensa;
		this.Tipo = Tipo;
		this.Completada = Completada;
		this.Active = Active;
		
	}
}


