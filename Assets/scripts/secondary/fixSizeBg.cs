using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class fixSizeBg : MonoBehaviour {
	private GameObject obj;
	private SpriteRenderer rend;
	

	void Awake() {
		if (GetComponent<Transform>().localScale != new Vector3(1f,1f,1f) ) return; // called only once
		obj = this.gameObject;
		rend = obj.GetComponent<SpriteRenderer>();
		float rendX = rend.bounds.max.x;
		float cameraX = Global.Instance.MaxCameraBounds.x;
		float cameraY = Global.Instance.MaxCameraBounds.y;
		float rendY = rend.bounds.max.y;

		obj.GetComponent<Transform>().localScale = new Vector3(cameraX / rendX, cameraY / rendY, 1f); 
	}
}
