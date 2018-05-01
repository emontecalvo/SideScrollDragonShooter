using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshmallowMgr : MonoBehaviour {

	public Marshmallow MarshmallowPrefab;

	private static MarshmallowMgr _inst = null;

	public static MarshmallowMgr inst {
		get {
			if (_inst == null) {
				_inst = FindObjectOfType<MarshmallowMgr> ();
			}
			return _inst;
		}
	}

	public List <Marshmallow> AllMarshmallows = new List<Marshmallow> ();

	public void Register (Marshmallow marshmallow) {

		AllMarshmallows.Add (marshmallow);

	}

	public void Unregister (Marshmallow marshmallow) {
		AllMarshmallows.Remove (marshmallow);
	}

	void Start () {
		float xpos = 9.77f;

		for (int i = 0; i < 10; i++) {
			Instantiate (MarshmallowPrefab);
			Vector3 suby = MarshmallowPrefab.transform.position;
			suby.y = 0;
			xpos += 10;
			suby.x = xpos;
			MarshmallowPrefab.gameObject.transform.position = suby;

		}


	}
}
