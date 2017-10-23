using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
	private static Global _instance;
	public static Global Instance {
	get {
		if (_instance == null) {
			GameObject go = new GameObject("Global");
			go.AddComponent<Global>();
		}

		return _instance;
	}
	}

	public enum ObjType {any, square, triangle, circle};

	private static ObjType _CurrentObjType;
	public static ObjType CurrentObjType {
		get {
			return _CurrentObjType;
		}
		set {
			_CurrentObjType = value;
		}
	}

	private int _ObjSpawnCount;
	public int ObjSpawnCount {
		get {
			return _ObjSpawnCount;
		}
	}

	// set {_GlobalScore = value;
	// TextLabel.text = _GlobalScore.ToString();
	// }
	public Vector2 MaxCameraBounds {
		get {
			return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
		}
	}

	public Vector2 MinCameraBounds {
		get {
			return Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
		}
	}

	void Awake() {
		_CurrentObjType = ObjType.any;
		_ObjSpawnCount = 10;
		_instance = this;
	}
}
