using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tugger : MonoBehaviour {
	private Transform[] grabbedObjs;
	private float radius;
	void Start () {
		InvokeRepeating("CheckArea", 0, 1f);
	}

	void Awake() {
		radius = Global.Instance.TuggerRange;
	}

	// void OnDrawGizmos() {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(GetComponent<Transform>().position, radius);
    // }

	void CheckArea() {
		print("check");
		Vector3 pos = GetComponent<Transform>().position;
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(new Vector2(pos.x, pos.y), radius);
		if (hitColliders.Length == 0) return;
		for (int i=0;i < hitColliders.Length; i++) {
			GameObject curr = hitColliders[i].gameObject;
			Transform currTr = curr.GetComponent<Transform>();
			if (hitColliders[i].tag != "Object") continue;
			DrawLine(currTr.position);
			// if (System.Array.IndexOf(grabbedObjs, curr) == -1) {
			// 	print(i);
			// }
		}
	}

	void DrawLine(Vector3 target) {
		Vector3 start = GetComponent<Transform>().position;

		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.startColor = Color.yellow;
		lr.endColor = Color.yellow;
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
		lr.SetPosition(0, start);
		lr.SetPosition(1, target);
	}
}
