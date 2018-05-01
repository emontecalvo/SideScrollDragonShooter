using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour {

	public GameObject FireImg;
	public float TimeUntilNextFrame;
	float TimeBetweenFrames = 0.1f;

	void Start() {
		TimeUntilNextFrame = TimeBetweenFrames;
	}

	void Update () {
		MovementLogic ();
		IsEnemyHit ();
		TimeUntilNextFrame -= Time.deltaTime;

		if (TimeUntilNextFrame <= 0) {
			TimeUntilNextFrame = TimeBetweenFrames;
			if (FireImg.activeSelf) {
				FireImg.SetActive (false);
			} else {
				FireImg.SetActive (true);
			}
		}
	}

	void MovementLogic () {
		Vector3 speed = Vector3.zero;

		speed.x += 5;

		transform.position = transform.position + speed * Time.deltaTime;
	}

	void IsEnemyHit() {
		foreach (Marshmallow marshmallow in MarshmallowMgr.inst.AllMarshmallows) {
			Vector3 toMarshmallow = marshmallow.transform.position - transform.position;
			float distance = toMarshmallow.magnitude;

			if (distance <= .3f) {
				marshmallow.HandleProjectileImpact ();
				Destroy (gameObject);
			}
		}

		if (transform.position.x > 8.5) {
			Destroy (gameObject);
		}
	}

}