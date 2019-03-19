using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public enum State {
        Patrol, seek
    }

    public State currentState;
    public Transform waypointParent;
    public float movespeed = 2f;
    public float stoppingDistance = 1f;

    public Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;
    private Transform target;
    // Use this for initialization
    void Start() {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
        currentState = State.Patrol;
    }

    // Update is called once per frame
    void Update() {
        switch(currentState) {
            case State.Patrol:
                Patrol();
                break;
            case State.seek:
                Seek();
                break;
            default:
                Patrol();
                break;
        }
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

    void Seek() {
        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            //set target to the thing that we hit
            target = other.transform;
            //switch state over to seek
            currentState = State.seek;
        }
    }

    private void OnTriggerExit(Collider other) {
        // switch back over to patrol
        if(other.gameObject.CompareTag("Player")) {
            currentState = State.Patrol;
        }
    }
}

//GITHUB TEST
