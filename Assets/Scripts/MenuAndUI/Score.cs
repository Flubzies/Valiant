using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	Text score;

	void Start()
	{
		score = GetComponent<Text>();
		StartCoroutine(UpdateScore());
	}

	IEnumerator UpdateScore()
	{
		while (true)
		{
			score.text = GameManager._Score.ToString();
			yield return new WaitForSeconds(0.1f);
		}
	}

}
