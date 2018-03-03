using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBody : MonoBehaviour
{

	bool isRewinding = false;

	public float recordTime = 5f;

	public Button abilityButton;
	public Image panel;

	List<PointInTime> pointsInTime;

	Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
		abilityButton.interactable = false;		
		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("joystick button 4") && abilityButton.IsInteractable())
			StartRewind();

	}

	void FixedUpdate()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind()
	{
		if (pointsInTime.Count > 0)
		{
			PointInTime pointInTime = pointsInTime[0];
			transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			pointsInTime.RemoveAt(0);
		}
		else
		{
			StopRewind();
		}

	}

	void Record()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
			abilityButton.interactable = true;		
		}


		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

	public void StartRewind()
	{
		panel.enabled = true;
		abilityButton.interactable = false;
		isRewinding = true;
		rb.isKinematic = true;
	}

	public bool IsRewinding()
	{
		return isRewinding;
	}

	public void StopRewind()
	{
		panel.enabled = false;		
		isRewinding = false;
		rb.isKinematic = false;
	}
}
