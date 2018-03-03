using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	Animator animator;
	int _points = 50;

	public static int _Speed { get; set; }
	

	void Awake()
	{
		_Speed = 3;
		animator = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		if(transform.position.y >= 10)
			GameManager.KillCoin(this, 1.0f);

		transform.Translate(Vector2.up * _Speed * Time.deltaTime);
	
	}

	void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col.gameObject.CompareTag("Player"))
		{
			animator.SetBool("CoinCollected", true);
			GameManager._Score += _points;
			GameManager.KillCoin(this, animator.GetCurrentAnimatorStateInfo(0).length + 0.4f);
		}
	}

}
