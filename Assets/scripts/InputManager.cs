using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {
	private static bool addBtnPressed = false;
	private float pressTimeout = 0.15f;
	private float pressTimeoutTimer = 0f;
	public void SetObjType(string type) {
		Global.CurrentObjType = Global.ParseEnum<Global.ObjType>(type);
	}

	public void ClearObjs() {
		Signals.OnClearReq();
	}

	public void handleAddPointerDown() {
		Signals.ObjSpawnRequest();
		addBtnPressed = true;
	}

	public void handleAddPointerUp() {
		pressTimeoutTimer = 0f;
		addBtnPressed = false;
	}


	void Update(){
		if(addBtnPressed) pressTimeoutTimer += Time.deltaTime;
		if (pressTimeoutTimer >= pressTimeout) {
			Signals.ObjSpawnRequest();
		}
	}
}
