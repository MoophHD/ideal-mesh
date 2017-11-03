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

    public delegate void KillPlayer();
    public static event KillPlayer OnKillPlayer;

    public static void PlayerKillReq() {OnKillPlayer();}

    public delegate void DestroyObj();
    public static event DestroyObj OnDestroyObj;

    public static void DestroyObjReq() {OnDestroyObj();}
}