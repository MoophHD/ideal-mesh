using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tugger : MonoBehaviour {
	private List <GameObject> grabbedObjs;
	private Vector3 pos;
	private float radius;
	private float force = 2.5f;
	private bool active = false;
	void Start () {
		InvokeRepeating("CheckArea", 0, 1f);
		pos = GetComponent<Transform>().position;
		grabbedObjs = Global.grabbedObjs;
	}

	void Awake() {
		radius = Global.Instance.TuggerRange;
	}
	void CheckArea() {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(new Vector2(pos.x, pos.y), radius);
		if (hitColliders.Length == 0) return;

		for (int i=0;i < hitColliders.Length; i++) {
			if (hitColliders[i].tag != "Object") continue;

			GameObject curr = hitColliders[i].gameObject;
			Transform currTr = curr.GetComponent<Transform>();
			if (grabbedObjs.IndexOf(curr) == -1) {
				grabbedObjs.Add(curr);
			}
		}


	}
	void Update() {
		pos = GetComponent<Transform>().position; 
		Global.Instance.TuggerPos = pos;
		if (Input.GetMouseButtonDown(1)) {
			active = true;
		} else if (Input.GetMouseButtonUp(1)) {
			active = false;
		}
		
		if (active) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			GetComponent<Transform>().position = ray.GetPoint(0f);
		}

		if (grabbedObjs.Count > 0) {
			foreach (GameObject obj in grabbedObjs.ToArray()) {
				if (obj == null) {grabbedObjs.Remove(obj); return;}

				if (obj.GetComponent<Rigidbody2D>().gravityScale != 0) obj.GetComponent<Rigidbody2D>().gravityScale = 0;
				obj.GetComponent<Rigidbody2D>().position = Vector3.Lerp(obj.GetComponent<Transform>().position, pos, Time.deltaTime*force);

				if ((obj.GetComponent<Transform>().position-pos).sqrMagnitude <= 94.65f) { //95
					grabbedObjs.Remove(obj);
					GameObject.Destroy(obj);
				}
			}
		}
	}
}
