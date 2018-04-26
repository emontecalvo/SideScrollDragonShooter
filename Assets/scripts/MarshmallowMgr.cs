using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshmallowMgr : MonoBehaviour {

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
}
