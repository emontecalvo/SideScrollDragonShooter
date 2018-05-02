using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marshmallow : MonoBehaviour {

	public Vector3 MarshmallowPosition;

	public float LeftWall = -9.0f;





	float originalY;

	public float floatStrength = 1; // You can change this in the Unity Editor to 
	// change the range of y positions that are possible.


	void Start () {
		MarshmallowMgr.inst.Register (this);
		MarshmallowPosition = transform.position;

		this.originalY = this.transform.position.y;
	}

	void Update () {
		MarshmallowMovement ();
		MarshmallowPosition = transform.position;

		transform.position = new Vector3(transform.position.x,
			originalY + ((float)Mathf.Sin(Time.time) * floatStrength),
			transform.position.z);
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

	public void HandleProjectileImpact() {
		Destroy (gameObject);
	}


}
