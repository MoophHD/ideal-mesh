using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject[] objs;
	private Color[] colors = {new Color((float)234/256,(float)165/256,(float)165/256), new Color((float)51/256,(float)51/256,(float)51/256)};

	private Transform ObjParent;

	private static GameManager _instance;
	public static GameManager Instance {
		get {
			if (_instance == null) {
				GameObject go = new GameObject("GameManager");
				go.AddComponent<GameManager>();
			}

			return _instance;
		}
	}	

	public void SpawnParticles() {
		// for (int i = 0; i < Global.Instance.ObjSpawnCount; i++) {
		// 	GameObject newInst = Instantiate(objs[0], new Vector3(0,0,0), Quaternion.identity);
		// 	newInst.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
		// }
		GameObject objType;
		if (Global.CurrentObjType == Global.ObjType.circle) {
			objType = objs[0];
		} else if (Global.CurrentObjType == Global.ObjType.square) {
			objType = objs[1];	
		} else if (Global.CurrentObjType == Global.ObjType.triangle) {
			objType = objs[2];
		} else {
			objType = objs[Random.Range(0, objs.Length)];
		}

		GameObject newInst = Instantiate(objType, new Vector3(0,2f,0), Quaternion.identity);
		newInst.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
		newInst.GetComponent<Transform>().SetParent(ObjParent);
	}

	void Awake() {
		ObjParent = GameObject.Find("ObjContainer").GetComponent<Transform>();
		_instance = this;
	}
}
