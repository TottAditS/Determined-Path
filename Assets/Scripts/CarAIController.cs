using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAIController : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;
    private float duration_start = 600f;
    private float currdurt;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetWaypoints();

        currentWaypointIndex = 0; // Inisialisasi index saat start
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void Update()
    {
        currdurt += Time.deltaTime;
        if (currdurt > duration_start)
        {
            currdurt = 0;
            Destroy(gameObject);
        }

        // Jika sudah mendekati waypoint saat ini
        if (agent.remainingDistance < agent.stoppingDistance + 2)
        {
            currentWaypointIndex++;

            // Pastikan currentWaypointIndex tidak melebihi jumlah waypoints
            if (currentWaypointIndex >= waypoints.Length)
            {
                // Jika sudah di waypoint terakhir, hancurkan object atau reset index
                Destroy(gameObject);
                return;
            }

            // Set tujuan berikutnya
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    private void SetWaypoints()
    {
        WaypointManager waypointManager = WaypointManager.Instance;

        if (waypointManager != null)
        {
            if (waypointManager.currpilih == WaypointManager.Pilihjalan.satu)
            {
                waypoints = waypointManager.WaypointJal1;
                return;
            }
            else if (waypointManager.currpilih == WaypointManager.Pilihjalan.dua)
            {
                waypoints = waypointManager.WaypointJal2;
                return;
            }

            if (waypointManager.currbalik == WaypointManager.Balikjalan.satu)
            {
                waypoints = waypointManager.Waybalik1;
                return;
            }
            else if (waypointManager.currbalik == WaypointManager.Balikjalan.dua)
            {
                waypoints = waypointManager.Waybalik2;
                return;
            }
        }
    }
}
