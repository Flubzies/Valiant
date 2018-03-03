using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayBehaviour : MonoBehaviour {

	public SpriteRenderer srW;
	public SpriteRenderer srY;


	public float _AlphaValW
	{
		get { return srW.color.a;}
		set { srW.color = new Color(srW.color.r, srW.color.g, srW.color.b, value);}
	}

	public float _AlphaValY
	{
		get { return srY.color.a;}
		set { srY.color = new Color(srY.color.r, srY.color.g, srY.color.b, value);}
	}

	void Start()
	{
		srW = srW.GetComponent<SpriteRenderer>();
		srY = srY.GetComponent<SpriteRenderer>();
	}

	public void Flash(float _para)
	{
		StartCoroutine(Flashing(_para));
	}

	IEnumerator Flashing(float _para)
	{	
		Mathf.Lerp(_para, 0.0f, Time.deltaTime);
	
		yield return new WaitForSeconds(0.1f);
	}


}
