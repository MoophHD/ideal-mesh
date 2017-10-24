using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
	public Transform toFollow;
	private GameObject myLine;
	private Vector3 start;
	private Color cl = Color.green;
	void Start() {
		start = this.gameObject.GetComponent<Transform>().position;

		myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.startColor = cl;
		lr.endColor = cl;
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
		lr.SetPosition(0, start);
	}

	void Update () {
		myLine.GetComponent<LineRenderer>().SetPosition(1, toFollow.position);
	}
}
