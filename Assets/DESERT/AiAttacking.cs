using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAttacking : MonoBehaviour
{
    public Transform Player;
    
    public float OutOfAttackRangeDistance;

    AiChasing aiChasing;
    public float AnimatorSpeed = 1.0f;
    [SerializeField] float damage = 10f;
    private bool alreadyAttacked = false;
    private void Start()
    {
        if (!Player) Player = GameObject.Find("Player").transform;
        aiChasing = GetComponent<AiChasing>();
        GetComponentInChildren<Animator>().speed = AnimatorSpeed;
    }

    private void OnEnable()
    {
        GetComponentInChildren<Animator>().Play("Attack1");
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) > OutOfAttackRangeDistance)
        {
            aiChasing.enabled = true;
            enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, OutOfAttackRangeDistance);
    }
}
