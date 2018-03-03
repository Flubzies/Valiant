using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class Menu : MonoBehaviour
{

	public GameObject _PauseUI;
	public GameObject _GameOverUI;

	bool _gameover;

	void Update()
	{
		if(GameManager._PlayerDead && !_gameover)
		{
			EnableGameOver();	
			_gameover = true;	
		}
	}

	void EnableGameOver()
	{
		_GameOverUI.SetActive(!_GameOverUI.activeSelf);
	}

	public void TogglePause()
	{
		_PauseUI.SetActive(!_PauseUI.activeSelf);

		if (_PauseUI.activeSelf)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
	}

	public void Retry()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Level01");
	}

	public void MainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void TogglePP()
	{
		PostProcessingBehaviour p = Camera.main.GetComponent<PostProcessingBehaviour>();
		if (p != null)
			p.enabled = !(p.enabled);
	}

}
