using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasing : MonoBehaviour
{
    NavMeshAgent NavMeshAgent;
    public Transform Player;

    public float OutOfRangeDistance;
    public float AttackDistance;

    public AiWandering AiWandering;

    public float DistanceToPlayer;
    Animator Animator;
    public float AnimatorSpeed = 1.0f;

    private void Start()
    {
        if (!Player) Player = GameObject.Find("Player").transform;
        Animator = GetComponentInChildren<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        AiWandering = GetComponent<AiWandering>();
        GetComponentInChildren<Animator>().speed = AnimatorSpeed;
    }

    private void OnEnable()
    {
        GetComponentInChildren<Animator>().Play("Walk");
    }

    void Update()
    {
        NavMeshAgent.destination = Player.position;
        DistanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (DistanceToPlayer > OutOfRangeDistance)
        {
            AiWandering.enabled = true;
            enabled = false;
        }

        if (DistanceToPlayer < AttackDistance)
        {
            GetComponent<AiAttacking>().enabled = true;
            enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, OutOfRangeDistance);
    }
}
