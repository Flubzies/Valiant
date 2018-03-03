using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incoming : MonoBehaviour 
{

	public int _stayDuration = 2;

	void Start()
	{
		transform.position = new Vector2(transform.position.x, -4);
		GameManager.KillIncoming(this, _stayDuration);	
	}
	
}
