using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

	Text level;

	void Start()
	{
		level = GetComponent<Text>();
		StartCoroutine(UpdateLevel());
	}

	IEnumerator UpdateLevel()
	{
		while (true)
		{
			level.text = GameManager._Difficulty.ToString();
			yield return new WaitForSeconds(0.1f);
		}
	}

}
