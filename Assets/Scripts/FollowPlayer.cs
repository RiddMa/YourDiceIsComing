using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FollowPlayer : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

    }
}
