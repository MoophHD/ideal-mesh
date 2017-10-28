using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {
	public Button addBtn;
	public static bool mouseDown;
	public float timeMouseDown;
	public void SetObjType(string type) {
		Global.CurrentObjType = Global.ParseEnum<Global.ObjType>(type);
	}

	// void Awake() {
	// 	addBtn.
	// }



	void Update(){
		if(mouseDown)
		timeMouseDown += Time.deltaTime;
	}

	void OnPointerDown(){
		mouseDown = true;
	}
	void OnPointerUp(){
		mouseDown = false;
		timeMouseDown = 0;
	}
}
