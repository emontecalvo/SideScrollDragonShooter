using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marshmallow : MonoBehaviour {

	public Vector3 MarshmallowPosition;

	public float LeftWall = -9.0f;


	void Start () {
		MarshmallowMgr.inst.Register (this);
		MarshmallowPosition = transform.position;
	}

	void Update () {
		MarshmallowMovement ();
		MarshmallowPosition = transform.position;

	}

	void MarshmallowMovement() {
		Vector3 myPosition = transform.position;

		if (myPosition.x > LeftWall) {
			myPosition.x -= .03f;
		} else {
			OnDestroy ();
			Destroy (gameObject);
		} 

		transform.position = myPosition;
	}

	void OnDestroy() {
		if (MarshmallowMgr.inst != null) {
			MarshmallowMgr.inst.Unregister (this);
		}
	}
}
