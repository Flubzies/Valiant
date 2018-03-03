using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	public float _playerSpeed = 10f;
	public float _tilt = -1f;

	Rigidbody2D _playerRB;
	Quaternion _calibrationQuaternion;
	public GameObject _deathEffect;

	TimeBody _timeBody;

	int _initialHealth = 3;
	public int _Health { get; set; }
	
	public SpriteRenderer _srLED;

	public static bool _Calibrated { get; set; }

	void Awake()
	{
		_Health = _initialHealth;
		_Calibrated = false;
		_playerRB = gameObject.GetComponent<Rigidbody2D>();
		_timeBody = GetComponent<TimeBody>();
		StartCoroutine(InitialCalibration());
	}

	void Controller()
	{
		Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		_playerRB.velocity = movement * (_playerSpeed/2);
	}

	IEnumerator InitialCalibration()
	{
		yield return new WaitForSeconds(1);
		CalibrateAccelerometer();
		_Calibrated = true;
	}

	public void Death()
	{
		GameObject clone = Instantiate(_deathEffect, transform.position, transform.rotation);
		Destroy(clone, 3.0f);
	}

	void FixedUpdate()
	{
		if (_Calibrated && !(_timeBody.IsRewinding()))
		{
			#if UNITY_ANDROID
			MovePlayerAccel();
			#endif
			#if UNITY_STANDALONE			
			Controller();
			#endif			
		}

	}

	void MovePlayerAccel()
	{

		Vector3 accelerationRaw = Input.acceleration;
		Vector3 acceleration = GetAccelerometer(accelerationRaw);
		Vector3 movement = new Vector3(acceleration.x, acceleration.y, acceleration.z);

		_playerRB.velocity = movement * _playerSpeed;

	}

	// Accelerometer calibration

	Matrix4x4 calibrationMatrix;
	Vector3 wantedDeadZone = Vector3.zero;

	public void CalibrateAccelerometer()
	{
		wantedDeadZone = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), wantedDeadZone);
		Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f, 1f, 1f));
		calibrationMatrix = matrix.inverse;
	}

	Vector3 GetAccelerometer(Vector3 accelerator)
	{
		Vector3 accel = this.calibrationMatrix.MultiplyVector(accelerator);
		return accel;
	}

	public void UpdateHealthLED()
	{
		switch(_Health)
		{
			case 3: _srLED.color = Color.green; break;
			case 2: _srLED.color = Color.yellow; break;
			case 1: _srLED.color = Color.red; break;
		}
	}

}