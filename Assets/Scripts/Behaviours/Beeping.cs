using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beeping : MonoBehaviour 
{

	SpriteRenderer _sr;
	public float _beepSpeed = 1.0f;

	public bool _randomIntervals = false;
	float _randValue = 1;

	void Start()
	{
		_sr = GetComponent<SpriteRenderer>();
		StartCoroutine(Beep());
	}

	IEnumerator Beep()
	{
		while(true)
		{
			_sr.enabled = !_sr.enabled;

			if(_randomIntervals)
				_randValue = Random.Range(0.6f, 3.2f);

			yield return new WaitForSeconds(_beepSpeed * _randValue);
		}
	}

}
