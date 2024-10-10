using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs; 
    public Transform spawnPointsejalan; 
    public Transform spawnPointbalik1;
    public Transform spawnPointbalik2;
    public float spawnInterval = 10f;
    void Start()
    {
       
        StartCoroutine(SpawnCarRoutine());
    }

    private IEnumerator SpawnCarRoutine()
    {
        while (true)
        {
            SpawnRandomCar(); 
            yield return new WaitForSeconds(spawnInterval); 
        }
    }

    public void SpawnRandomCar()
    {

        WaypointManager waypointManager = WaypointManager.Instance;

        if (waypointManager != null)
        {
            int randomIndex = Random.Range(0, carPrefabs.Length);
            GameObject carPrefab = carPrefabs[randomIndex];
            //Debug.Log("ngespawnih");

            if (waypointManager.currpilih == WaypointManager.Pilihjalan.satu)
            {
                Instantiate(carPrefab, spawnPointsejalan.position, spawnPointsejalan.rotation);
                //Debug.Log("di j1");
                return;
            }
            else if (waypointManager.currpilih == WaypointManager.Pilihjalan.dua)
            {
                Instantiate(carPrefab, spawnPointsejalan.position, spawnPointsejalan.rotation);
                //Debug.Log("di j2");
                return;
            }

            if (waypointManager.currbalik == WaypointManager.Balikjalan.satu)
            {
                Instantiate(carPrefab, spawnPointbalik1.position, spawnPointbalik1.rotation);
                //Debug.Log("di b1");
                return;
            }
            else if (waypointManager.currbalik == WaypointManager.Balikjalan.dua)
            {
                Instantiate(carPrefab, spawnPointbalik2.position, spawnPointbalik2.rotation);
                //Debug.Log("di b2");
                return;
            }
        }
    }
}
