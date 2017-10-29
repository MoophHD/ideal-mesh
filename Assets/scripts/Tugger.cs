using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tugger : MonoBehaviour {
	private Transform[] grabbedObjs;
	private float radius;
	void Start () {
		radius = Global.Instance.TuggerRange;
		InvokeRepeating("CheckArea", 0, 1f);
	}

	// void OnDrawGizmos() {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(GetComponent<Transform>().position, 10);
    // }

	void CheckArea() {
		print("check");
		Collider[] hitColliders = Physics.OverlapSphere(GetComponent<Transform>().position, radius);
		print(hitColliders.Length);
		for (int i=0; i<hitColliders.Length;i++) {
			Transform curr = hitColliders[i].gameObject.GetComponent<Transform>();
			if (System.Array.IndexOf(grabbedObjs, curr) == -1) {
				print(i);
			}
		}
	}
}
