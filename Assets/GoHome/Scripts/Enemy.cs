using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public Transform waypointParent;
    public float movespeed = 2f;
    public float stoppingDistance = 1f;

    public Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;
    // Use this for initialization
    void Start() {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        Patrol();
    }

    void Patrol() {
        //1 -   get current waypoint
        Transform point = waypoints[currentIndex];

        //2 -   get distancec to waypoint
        float distance = Vector3.Distance(transform.position, point.position);

        //3 -   if close to waypoint
        if(distance < stoppingDistance) {
            //      4   -   switch to next waypoint
            currentIndex++;
            if(currentIndex >= waypoints.Length) {
                currentIndex = 1;
            }
        }

        //5 -   translate enemy to waypoint
        // transform.position = Vector3.MoveTowards(transform.position,
        //    point.position, movespeed * Time.deltaTime);
        agent.SetDestination(point.position);
    }
}
