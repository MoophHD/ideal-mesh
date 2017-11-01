using UnityEngine;
using System.Collections;

public class Signals : MonoBehaviour 
{
    public delegate void AddObj();
    public static event AddObj OnObjSpawn;

    public static void ObjSpawnRequest() {OnObjSpawn();}

    public delegate void ClearObjs();
    public static event ClearObjs OnClear;

    public static void OnClearReq() {OnClear();}
}