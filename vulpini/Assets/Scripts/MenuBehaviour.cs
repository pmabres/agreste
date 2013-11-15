using UnityEngine;
using System.Collections;

public class MenuBehaviour : MonoBehaviour {
	// Use this for initialization
	void Start () 
	{		
	}	
	// Update is called once per frame
	void FixedUpdate () 
	{
			
		if (Input.touchCount>0 && Statics.Paused)
		{
			if (Input.GetTouch(0).position.x>Screen.width*Constants.TOUCH_SCREEN_WIDTH_PROPORTION &&
				Input.GetTouch(0).position.x<Screen.width - Screen.width * Constants.TOUCH_SCREEN_WIDTH_PROPORTION &&
				Input.GetTouch(0).position.y>Screen.height*Constants.TOUCH_SCREEN_HEIGHT_PROPORTION &&
				Input.GetTouch(0).position.y<Screen.height - Screen.height * Constants.TOUCH_SCREEN_HEIGHT_PROPORTION)
			{		
				if (Statics.GameOver.activeSelf)
				{
					Statics.RestartGame=true;
				}
				Statics.Paused = false;			
				Statics.GameOver.SetActive(false);
				Statics.Menu.SetActive(false);
				Statics.HUD.SetActive(true);
				Statics.Paw.SetActive(false);
				Statics.PreC.SetActive(false);
				Statics.PreC.GetComponent<PreAdqBehaviour>().Swich(false);
				Statics.Titulo.SetActive(false);
			}
		}
		//MOUSE
		else if (Input.GetMouseButtonDown(0) && Statics.Paused)
		{	
			if(Input.mousePosition.x >Screen.width*Constants.TOUCH_SCREEN_WIDTH_PROPORTION &&
			   Input.mousePosition.x <Screen.width - Screen.width * Constants.TOUCH_SCREEN_WIDTH_PROPORTION &&
			   Input.mousePosition.y >Screen.height*Constants.TOUCH_SCREEN_HEIGHT_PROPORTION &&
			   Input.mousePosition.y <Screen.height - Screen.height * Constants.TOUCH_SCREEN_HEIGHT_PROPORTION)
			{
			
				if (Statics.GameOver.activeSelf)
				{
					Statics.RestartGame=true;
				}
				else if(Statics.Paused == true)
				{
					Statics.Paused = false;			
					Statics.GameOver.SetActive(false);
					Statics.Menu.SetActive(false);
					Statics.HUD.SetActive(true);
					Statics.Paw.SetActive(true);
					Statics.PreC.SetActive(false);
					Statics.PreC.GetComponent<PreAdqBehaviour>().Swich(false);
					Statics.Titulo.SetActive(false);
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && !Statics.Paused) 	   	
		{
			Statics.Paused = true;
			Statics.Paw.SetActive(true);
			Statics.Menu.SetActive(true);
			Statics.Titulo.SetActive(true);
			GameObject.FindGameObjectWithTag(Constants.TAG_MAIN).GetComponent<GameProgression>().Save();
		}	
		else if (Input.GetKeyDown(KeyCode.Escape) && Statics.Paused)
		{
			Debug.Log("QUIT");
			//Application.Quit();
		}
	}	
}
