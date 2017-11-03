using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour{
    void Start() {
        InvokeRepeating("checkPos", 0f, 5f);
    }
    void checkPos() {
        if (GetComponent<LineRenderer>()) return;
        
        Vector3 pos = GetComponent<Transform>().position;
        if (pos.x > Global.Instance.MaxCameraBounds.x || pos.y > Global.Instance.MaxCameraBounds.y ||
            pos.x <  Global.Instance.MinCameraBounds.x || pos.y < Global.Instance.MinCameraBounds.y) {
                Signals.DestroyObjReq();
                Destroy(gameObject);
            }
    }
     public bool isCorrupted;
}