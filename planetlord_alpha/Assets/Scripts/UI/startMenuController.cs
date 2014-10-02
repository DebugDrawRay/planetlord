using UnityEngine;
using System.Collections;

public class startMenuController : MonoBehaviour 
{
	public string levelToLoad;
	public GameObject helpMenu;

	void Awake()
	{
		Screen.showCursor = true;
	}
	
	void Update () 
	{
		
	}
	
	public void startGame()
	{
		Application.LoadLevel(levelToLoad);
	}
	
	public void exitGame()
	{
		Application.Quit();
	}

	public void showHelp(bool shown)
	{
		helpMenu.SetActive(shown);
	}

}
