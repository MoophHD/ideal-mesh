using UnityEngine;
using System.Collections;

public class Signals : MonoBehaviour 
{
    public delegate void AddObj();
    public static event AddObj OnObjSpawn;

    public static void ObjSpawnRequest() {OnObjSpawn();}
}