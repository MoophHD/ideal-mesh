using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject[] objs;
	private Color[] colors = {new Color((float)234/256,(float)165/256,(float)165/256), new Color((float)51/256,(float)51/256,(float)51/256)};
	private Color corruptedObjColor = new Color((float)134/256,(float)0/256,(float)200/256);
	private Transform ObjParent;
	private int CorruptedObjSpawnRate = 15;

	void OnEnable() {
		Signals.OnObjSpawn += SpawnParticles;
		Signals.OnClear += Clear;
	}

	void OnDisable()
    {
        Signals.OnObjSpawn -= SpawnParticles;
		Signals.OnClear -= Clear;
    }

	void Clear() {
		foreach (Transform child in ObjParent) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void ToggleAutoSpawn() {
		bool oldBool = Global.Instance.AutoSpawn;
		if (!oldBool) {
			InvokeRepeating("SpawnParticles", 0f, 0.25f);
		} else {
			CancelInvoke("SpawnParticles");
		}

		Global.Instance.AutoSpawn = !oldBool;
	}

	void SpawnParticles() {
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

		GameObject newInst = Instantiate(objType, new Vector3(getRandomHorizontalPos(),5f,0), Quaternion.identity);

		if (Random.Range(0, 100) <= CorruptedObjSpawnRate) {
			newInst.GetComponent<Obj>().isCorrupted =true;
			newInst.GetComponent<SpriteRenderer>().color = corruptedObjColor;
		} else {
			newInst.GetComponent<Obj>().isCorrupted =false;
			newInst.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
		}

		newInst.GetComponent<Transform>().SetParent(ObjParent);
	}

	float getRandomHorizontalPos() {
		return Random.Range(Global.Instance.MinCameraBounds.x, Global.Instance.MaxCameraBounds.x);
	}

	void Awake() {
		ObjParent = GameObject.Find("ObjContainer").GetComponent<Transform>();
	}
}
