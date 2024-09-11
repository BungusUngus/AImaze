using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Monster : MonoBehaviour
{
    private NavMeshAgent _agent;

    private MoveToClick _player;

    public float range;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<MoveToClick>();
    }

    void FixedUpdate()
    {
        //direction to player also tells us that the dirToPlayer holds the players position and current position
        Vector3 dirToPlayer = _player.transform.position - transform.position;

        //holds raycast on monster position and tells us the direction to the player and what the raycast is hitting aswell as the distance of the actual raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dirToPlayer, out hit ,30f))
        {
            //if raycast hits play transform trigger Monster to follow to player destination
            if (hit.transform == _player.transform)
            {
                _agent.destination = _player.transform.position;
            }
        }

        //if the raycast can't find the player have the monster patrol a random area around it's feet
        else
        {
            if (_agent.pathPending || !_agent.isOnNavMesh || _agent.remainingDistance > 0.1f)
            {
                //If we currently have a path to follow, exit the function
                return;
            }

            //Choose a random point 
            Vector3 randomPosition = range * Random.insideUnitCircle;
            randomPosition = new Vector3(randomPosition.x, 0, randomPosition.y);
            _agent.destination = transform.position + randomPosition;
        }
       
    }
}
