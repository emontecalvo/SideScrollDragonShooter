using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour {


	private static Dragon _inst = null;

	public static Dragon inst {
		get {
			if (_inst == null) {
				_inst = FindObjectOfType<Dragon> ();
			}
			return _inst;
		}
	}

	public KeyCode LeftKey;
	public KeyCode RightKey;
	public KeyCode UpKey;
	public KeyCode DownKey;

	public Vector3 CurrentDragonPosition;

	void Start () {
		CurrentDragonPosition = transform.position;
	}


	void Update () {
		MovementLogic ();
		CurrentDragonPosition = transform.position;
	}

	void MovementLogic () {
		Vector3 speed = Vector3.zero;

		if (CurrentDragonPosition.x > -1.8f) {
			if (Input.GetKey (LeftKey)) {
				speed.x = -5;
			}
		}

		if (CurrentDragonPosition.x < 13.2f) {
			if (Input.GetKey (RightKey)) {
				speed.x = 5;
			}
		}

		if (CurrentDragonPosition.y < 5.0f) {
			if (Input.GetKey (UpKey)) {
				speed.y = 5;
			}
		}


		if (CurrentDragonPosition.y > -5.0f) {
			if (Input.GetKey (DownKey)) {
				speed.y = -5;
			}
		}


		transform.position = transform.position + speed * Time.deltaTime;
	}


}