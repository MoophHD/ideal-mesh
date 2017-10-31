using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tugger : MonoBehaviour {
	private List <GameObject> grabbedObjs = new List <GameObject>();

	private float radius;
	private float force = 5f;
	private bool active = false;
	void Start () {
		InvokeRepeating("CheckArea", 0, 1f);
	}

	void Awake() {
		radius = Global.Instance.TuggerRange;
	}
	void CheckArea() {
		Vector3 pos = GetComponent<Transform>().position;
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
			foreach (GameObject obj in grabbedObjs) {
				obj.GetComponent<Rigidbody2D>().gravityScale = 0;
				obj.GetComponent<Rigidbody2D>().position = Vector3.Lerp(obj.GetComponent<Transform>().position, GetComponent<Transform>().position, Time.deltaTime*force);
			}
		}
	}
}
