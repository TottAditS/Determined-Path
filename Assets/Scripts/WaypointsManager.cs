using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TrafficScript;

public class WaypointManager : MonoBehaviour
{
    public Transform[] WaypointJal1; 
    public Transform[] WaypointJal2;
    public Transform[] Waybalik1;
    public Transform[] Waybalik2;
    public float spawnInterval = 10f;

    public enum Pilihjalan { satu, dua }
    public enum Balikjalan { satu, dua }
    public Pilihjalan currpilih;
    public Balikjalan currbalik;

    private static WaypointManager _instance;

    private void Start()
    {
        StartCoroutine(CycleJalanan());
    }
    public static WaypointManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<WaypointManager>();
            }
            return _instance;
        }
    }

    private IEnumerator CycleJalanan()
    {
        while (true)
        {
            currbalik = Balikjalan.satu;
            currpilih = Pilihjalan.satu;
            //Debug.Log("satu");
            yield return new WaitForSeconds(spawnInterval+1);
            //
            //Debug.Log("dua");
            currbalik = Balikjalan.dua;
            currpilih = Pilihjalan.dua;
            yield return new WaitForSeconds(spawnInterval+1);
        }
    }
}
