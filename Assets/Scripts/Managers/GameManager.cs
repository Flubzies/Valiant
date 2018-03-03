using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager gm;
	float _difficultyTimer = 10;

	public static int _Difficulty { get; set; }
	public static int _Score { get; set; }

	public static bool _PlayerDead { get; set; }

	void Awake()
	{
		if (gm == null)
			gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	void Start()
	{
		_PlayerDead = false;
		Time.timeScale = 1f;
		ResetStatics();
		StartCoroutine(IncreaseDifficulty());
	}

	IEnumerator IncreaseDifficulty()
	{
		while (true)
		{
			yield return new WaitForSeconds(_difficultyTimer);
			OverlayBehaviour ob = Camera.main.GetComponent<OverlayBehaviour>();

			if (ob != null)
				ob.Flash(ob._AlphaValW);

			_Difficulty++;
		}
	}

	public static void KillPlayer(Player _player, float delay)
	{
		_player.Death();
		Destroy(_player.gameObject, delay);
		_PlayerDead = true;
	}

	public static void DamagePlayer(Player _player)
	{
		_player._Health--;

		if (_player._Health <= 0)
		{
			KillPlayer(_player, 0.0f);
		}
		else
			_player.UpdateHealthLED();

	}

	public static void KillCoin(Coin _coin, float delay)
	{
		Destroy(_coin.gameObject, delay);
	}

	public static void KillIncoming(Incoming _inc, float delay)
	{
		Destroy(_inc.gameObject, delay);
	}

	public static void KillDebris(Debris _d, float delay)
	{
		Destroy(_d.gameObject, delay);
	}

	public static void ResetStatics()
	{
		_Difficulty = 0;
		_Score = 0;
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Level01");
	}

	public void Exit()
	{
		Application.Quit();
	}


}
