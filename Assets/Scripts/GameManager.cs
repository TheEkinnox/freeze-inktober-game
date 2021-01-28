using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	[SerializeField] private GameObject infosMenu;
	// Start is called before the first frame update
	private void Start()
	{
		this.infosMenu.SetActive(false);
	}

	// Update is called once per frame
	private void Update()
	{
		if(Input.GetButtonDown(Inputs.Exit))
		{
			if(!this.infosMenu.activeInHierarchy)
				QuitGame();
			else
				HideInfos();
		}
	}

	public void Play()
	{
		SceneManager.LoadScene(Scenes.Game);
	}
	public void QuitGame()
	{
		Application.Quit();
	}

	public void ShowInfos()
	{
		this.infosMenu.SetActive(true);
	}
    
	public void HideInfos()
	{
		this.infosMenu.SetActive(false);
	}
}