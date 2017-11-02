using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
	private GameObject myLine;
	private Vector3 start;
	private Color cl = Color.black;

	private Vector3 anchor;

	void Start() {
		anchor = Global.Instance.TuggerPos;
	}

	void addLine(GameObject toAddTo) {
		toAddTo.AddComponent<LineRenderer>();
		LineRenderer lr = toAddTo.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.startColor = cl;
		lr.endColor = cl;
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
	}

	void Update() {
		anchor = Global.Instance.TuggerPos;
		foreach (GameObject obj in Global.grabbedObjs.ToArray()) {
			if (!obj.GetComponent<LineRenderer>()) addLine(obj);
			LineRenderer lr = obj.GetComponent<LineRenderer>();
			lr.SetPosition(0, anchor);
			lr.SetPosition(1, obj.GetComponent<Transform>().position);
		}
		
	}
}
