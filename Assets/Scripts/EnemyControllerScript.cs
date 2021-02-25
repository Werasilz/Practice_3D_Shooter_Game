using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerScript : MonoBehaviour
{
    public Transform goal;
    public int hp = 3;

    private void Update()
    {
        FindPlayer();
        CheckHP();
    }

    void FindPlayer()
    {
        goal = GameObject.Find("Player").GetComponent<Transform>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void CheckHP()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
