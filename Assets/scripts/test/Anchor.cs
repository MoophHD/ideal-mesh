using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour {
	private List <GameObject> grabbedObjs = new List <GameObject>();

	private float radius = 1f;
	private bool active = false;
	void Start () {
		InvokeRepeating("CheckArea", 0, 1f);
	}

	// void OnDrawGizmos() {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(GetComponent<Transform>().position, radius);
    // }

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

	 public void ButtonPressed() {
		 print("!");
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
				obj.GetComponent<Rigidbody2D>().position = Vector3.Lerp(obj.GetComponent<Transform>().position, GetComponent<Transform>().position, 0.05f);
			}
		}
	}
}
