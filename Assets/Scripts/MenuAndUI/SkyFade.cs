using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyFade : MonoBehaviour {

	float _skyMoveSpeed = 0.01f;

	void Update()
	{
		transform.Translate(Vector2.up * Time.deltaTime * _skyMoveSpeed);
	}
	
}
