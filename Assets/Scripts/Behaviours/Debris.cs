using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{

	Rigidbody2D _rb;
	public float _moveSpeed = 10;
	public GameObject _deathEffect;


	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_rb.velocity = Vector2.up * _moveSpeed;
	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.tag == "Player" && !(collisionInfo.gameObject.GetComponent<Rigidbody2D>().isKinematic))
		{
			GameManager.DamagePlayer(collisionInfo.gameObject.GetComponent<Player>());
			Death();
			GameManager.KillDebris(this, 0.0f);
		}	
	}

	void Update()
	{
		if(transform.position.y >= 10)
			GameManager.KillDebris(this, 0.1f);
	}

	void Death()
	{
		GameObject clone = Instantiate(_deathEffect, transform.position, transform.rotation);
		Destroy(clone, 3.0f);
	}

}
