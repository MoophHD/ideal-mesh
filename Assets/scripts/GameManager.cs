using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject[] objs;
	private Color[] colors = {new Color((float)234/256,(float)165/256,(float)165/256), new Color((float)51/256,(float)51/256,(float)51/256)};

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
		// if (Global.CurrentObjType == Global.ObjType.any) {
		// 	print("!");
		// }
		// for (int i = 0; i < Global.Instance.ObjSpawnCount; i++) {
		// 	GameObject newInst = Instantiate(objs[0], new Vector3(0,0,0), Quaternion.identity);
		// 	newInst.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
		// }

		GameObject newInst = Instantiate(objs[0], new Vector3(0,0,0), Quaternion.identity);
		newInst.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
	}

	void Awake() {
		_instance = this;
	}
}
