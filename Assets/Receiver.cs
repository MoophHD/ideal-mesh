using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour {
	public GameObject obj1;
	public GameObject obj2;
	
	public void AddDist() {
		obj1.GetComponent<DistanceJoint2D>().distance += 0.5f;
	}

	public void RmDist() {
		obj1.GetComponent<DistanceJoint2D>().distance -= 0.5f;
	}
}
