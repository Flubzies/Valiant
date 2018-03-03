using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSnapshot : MonoBehaviour {

	public bool _score;
	public bool _level;

	int score;
	int level;

	void Start()
	{
		if(_score)
		{
			int score = GameManager._Score;
			transform.GetComponent<Text>().text = "SCORE: " + score.ToString();
		}

		if(_level)
		{
			int level = GameManager._Difficulty;
			transform.GetComponent<Text>().text = "LEVEL: " + level.ToString();
		}
	}
}
