using UnityEngine;
using System.Collections;

public class PreAdqBehaviour : MonoBehaviour {
	public Camera cam;	
	public GameObject pre1;
	public GameObject pre2;
	public GameObject pre3;
	public GameObject pre4;
	public GameObject preDesc;
	public GameObject selected;

	bool display = false;
	Ray cursorRay;
	RaycastHit hit;
	
	// Use this for initialization
	void Start () {
		Swich(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Statics.Menu.activeSelf==true && Statics.Paused)
		{
			if (Input.GetTouch (0).phase == TouchPhase.Began)
			{
				cursorRay = cam.ScreenPointToRay(Input.GetTouch(0).position);			
				if(collider.Raycast( cursorRay, out hit, 1000.0f) && !display)
	            {
					Swich(true);
	            }
				else if(pre1.collider.Raycast(cursorRay,out hit, 1000.0f))
				{
					if(selected != pre1)
					{
						selected = pre1;
						Desc(15);
						preDesc.GetComponent<TextMesh>().text = "Inicio Adelantado \n 400mts. \n Coste: 15 Paws.";
					}
					else if(Statics.Paws > 15)
					{
						Statics.Player.GetComponent<BoxCollider>().size = new Vector3(0,0,0);
						Statics.Player.GetComponent<Avanzar>().Pre1 = true;
						Statics.Player.GetComponent<Avanzar>().ghost = true;
						Statics.Paws -= 15;
						Swich(false);
					}
				}

				else if(pre2.collider.Raycast(cursorRay, out hit, 1000.0f))
				{
					if(selected != pre2)
					{
						selected = pre2;
						Desc(20);
						preDesc.GetComponent<TextMesh>().text = "Salud \n Nivel: " + Statics.MaxHealth + " \n Coste: 20 Paws.";
					}
					else if(Statics.Paws > 20)
					{
						Statics.Paws -= 20;
						Statics.MaxHealth ++;
						GameObject.FindGameObjectWithTag(Constants.TAG_MAIN).GetComponent<GameProgression>().Save();
						Swich(false);
					}
				}

				else if(pre3.collider.Raycast(cursorRay, out hit, 1000.0f))
				{
					if(selected != pre3)
					{
						selected = pre3;
						Desc(20);
						preDesc.GetComponent<TextMesh>().text = "Velocidad \n Nivel: " + Statics.Velocity + " \n Coste: 20 Paws.";
					}
					else
					{
						Statics.Paws -= 20;
						Statics.Velocity += 0.3f;
						GameObject.FindGameObjectWithTag(Constants.TAG_MAIN).GetComponent<GameProgression>().Save();
						Swich(false);
					}
				}
				else if(pre4.collider.Raycast(cursorRay, out hit, 1000.0f))
				{
					if(selected != pre4)
					{
						selected = pre4;
						Desc(30);
						preDesc.GetComponent<TextMesh>().text = "Agilidad \n Nivel: " + Statics.Agility + " \n Coste: 20 Paws.";
					}
					else
					{
						Statics.Paws -= 30;
						Statics.Agility += 0.5f;
						GameObject.FindGameObjectWithTag(Constants.TAG_MAIN).GetComponent<GameProgression>().Save();
						Swich(false);
					}
				}
			}
		}
	}
	void Desc(int Cost)
	{
		if(Statics.Paws>Cost)
		{ preDesc.GetComponent<TextMesh>().color = Color.white;}
		else
		{ preDesc.GetComponent<TextMesh>().color = Color.red;}
	}
	void Swich( bool x)
	{
		pre1.SetActive(x);
		pre2.SetActive(x);
		pre3.SetActive(x);
		pre4.SetActive(x);
		preDesc.SetActive(x);
		display = x;
	}
}
