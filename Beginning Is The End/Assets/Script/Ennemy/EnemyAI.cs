using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class EnemyAI : MonoBehaviour
{
    private Random rnd;

    [Header("References")] private Transform _target;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Animator animator;

    [Header("Stats")][SerializeField] private float walkSpeed = 2;

    [SerializeField] private float chaseSpeed = 3.5f;

    [SerializeField] private float attractionDistance = 6f;

    private float attackRadius = 1.5f;

    [SerializeField] private float attackDelay = 2.633f;

    [SerializeField] private float rotationSpeed = 120;

    [Header("Wandering parameters")]
    [SerializeField]
    private int wanderingWaitTimeMin = 2;

    [SerializeField] private int wanderingWaitTimeMax = 5;

    [SerializeField] private int wanderingDistanceMin = 3;

    [SerializeField] private int wanderingDistanceMax = 6;

    private bool _hasDestination = false;
    private bool _isAttacking = false;

    private void Start()
    {
        rnd = new Random();
    }

    private void Update()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");

        var closestPlayer = players[0];

        foreach (var player in players)
        {
            if (Vector3.Distance(transform.position,
                    player.transform.position) < Vector3.Distance(
                    transform.position, closestPlayer.transform.position))
            {
                closestPlayer = player;
            }
        }

        _target = closestPlayer.transform;

        if (Vector3.Distance(_target.position, transform.position) <=
            attractionDistance)
        {
            agent.speed = chaseSpeed;

            Quaternion rot =
                Quaternion.LookRotation(_target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot,
                Time.deltaTime * rotationSpeed);

            if (!_isAttacking)
            {
                if (Vector3.Distance(_target.position, transform.position) <=
                    attackRadius)
                {
                    StartCoroutine(attackPlayer());
                    _target.GetComponent<Player>().TakeDamage(5);
                }
                else
                {
                    agent.SetDestination(_target.position);
                }
            }
        }
        else if (agent.remainingDistance <= 0.75f && !_hasDestination)
        {
            agent.speed = walkSpeed;
            StartCoroutine(GetNewDestination());
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    private IEnumerator GetNewDestination()
    {
        _hasDestination = true;
        yield return new WaitForSeconds(rnd.Next(wanderingWaitTimeMin,
            wanderingWaitTimeMax));

        var nextDestination = transform.position;
        nextDestination +=
            rnd.Next(wanderingDistanceMin, wanderingDistanceMax) *
            new Vector3(rnd.Next(-1, 1), 0, rnd.Next(-1, 1)).normalized;

        if (NavMesh.SamplePosition(nextDestination, out var hit,
                wanderingDistanceMax, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }

        _hasDestination = false;
    }

    private IEnumerator attackPlayer()
    {
        _isAttacking = true;
        agent.isStopped = true;

        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(attackDelay);
        agent.isStopped = false;
        _isAttacking = false;
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, attractionDistance);
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawWireSphere(transform.position, attackRadius);
    // }
}