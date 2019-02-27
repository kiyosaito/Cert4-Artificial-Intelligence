using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour {

    public Transform target;

    private NavMeshAgent agent;
    //reference to the NavMeshAgent component
	// Use this for initialization
	void Start () {
        agent = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.position);
        //update destination of NavMeshAgent
	}
}
