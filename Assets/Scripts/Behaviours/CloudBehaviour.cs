using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour 
{

	float _cloudMoveSpeed = 1.0f;
	CloudManager _cloudManager;
	
	public int _despawnPosition;

	void Start()
	{
		_cloudMoveSpeed = Random.Range(2f, 6f);
		
		if(_cloudManager == null)
		{
			_cloudManager = GameObject.FindGameObjectWithTag("CloudManager").GetComponent<CloudManager>();
		}
	}

	void Update()
	{
		transform.Translate(Vector2.up * _cloudMoveSpeed * Time.deltaTime);

		if(transform.position.y >= 15.0f)
		{	
		 	_cloudManager.ResetCloud(transform);
		}
	}
	
}
