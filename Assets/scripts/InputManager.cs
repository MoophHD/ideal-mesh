using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	public void SetObjType(string type) {
		Global.CurrentObjType = Global.ParseEnum<Global.ObjType>(type);
		print(Global.CurrentObjType);
	}
}
