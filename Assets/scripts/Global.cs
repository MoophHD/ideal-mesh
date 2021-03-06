﻿using System.Collections;
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
	public static int GetObjCount() {
		return GameObject.Find("ObjContainer").GetComponent<Transform>().childCount;
	}

	public static T ParseEnum<T>(string value)
	{
		return (T) System.Enum.Parse(typeof(T), value, true);
	}

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

	public Vector3 TuggerPos {get;set;}
	public bool AutoSpawn {get;set;}

	private float _TuggerRange;
	public float TuggerRange {get{return _TuggerRange;}}

	public static List <GameObject> grabbedObjs;

	private int _Health;
	public int Health {
		get {
			return _Health;
		}
		set {
			_Health = value;
			if (_Health <= 0) {
				Signals.PlayerKillReq();
			}
		}
	}

	void Awake() {
		grabbedObjs = new List <GameObject>();
		AutoSpawn = false;
		_CurrentObjType = ObjType.any;
		_instance = this;
		_TuggerRange = 2.5f;
		_Health = 1;
	}
}
