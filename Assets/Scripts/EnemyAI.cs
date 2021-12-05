using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Player;
    public LayerMask WhatIsGround, WhatIsPlayer;

    //patroli
    public Vector3 walkpoint;
    bool walkpointset;
    public float walkpointRange;

    //serang
    public float timeBetweenAttack;
    public bool alreadyAttack;

    //State
    public float sigtRange, attackRange;
    public bool playerinsightRange, playerinAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerinsightRange = Physics.CheckSphere(transform.position, sigtRange, WhatIsPlayer);
        playerinAttackRange = Physics.CheckSphere(transform.position.normalized, attackRange, WhatIsPlayer);

        if (!playerinsightRange && !playerinAttackRange)
        {
            patroli();
        }
        if (playerinsightRange && !playerinAttackRange)
        {
            kejar();
        }
        if (playerinsightRange && playerinAttackRange)
        {
            serang();
        }
    }

    private void patroli()
    {
        if (!walkpointset)
        {
            searchwalkpoint();
        }

        if (walkpointset)
        {
            agent.SetDestination(walkpoint);
        }

        Vector3 distanceTowalkpoint = transform.position - walkpoint;

        //musuh sampai tujuan
        if (distanceTowalkpoint.magnitude < 1f)
        {
            walkpointset = false;
        }
    }

    private void searchwalkpoint()
    {
        float randomZ = Random.Range(-walkpointRange, walkpointRange);
        float randomX = Random.Range(-walkpointRange, walkpointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkpoint, - transform.up, 2f, WhatIsGround))
        {
            walkpointset = true;
        }
    }

    private void kejar()
    {
        agent.SetDestination(Player.position);
    }

    private void serang()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(Player);

        if (!alreadyAttack)
        {
            //script attack
            alreadyAttack = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        alreadyAttack = false;
    }
}
