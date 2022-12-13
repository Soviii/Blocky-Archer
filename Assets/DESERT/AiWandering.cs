using UnityEngine;
using UnityEngine.AI;

// NOTE: if the AI is going under the ground when using terrains, make sure to rebake navigation for the terrain!

public class AiWandering : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;
    public Transform Player;

    public Transform[] PatrolLocations;

    int index = 0;

    public AiChasing AiChasing;

    public float VisionRange = 3.0f;

    Animator Animator;

    public float DistanceToPlayer;

    public float AnimatorSpeed = 1.0f;

    private void OnEnable()
    {
        GetComponentInChildren<Animator>().Play("Walk");
        GetComponentInChildren<Animator>().speed = AnimatorSpeed;
    }

    private void Start()
    {
        if (!Player) Player = GameObject.Find("Player").transform;
        NavMeshAgent.destination = PatrolLocations[index].position;
        Animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, NavMeshAgent.destination) < 1.0f)
        {
            GoToNextDestination();
        }
        DistanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if (DistanceToPlayer < VisionRange)
        {
            AiChasing.enabled = true;
            enabled = false;
        }
    }

    private void GoToNextDestination()
    {
        index++;
        if (index == PatrolLocations.Length) index = 0;
        NavMeshAgent.destination = PatrolLocations[index].position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, VisionRange);
        if (PatrolLocations.Length > 0)
        {
            for (int i = 0; i < PatrolLocations.Length; i++)
            {
                Gizmos.DrawWireSphere(PatrolLocations[i].position, 0.5f);
                Gizmos.DrawLine(PatrolLocations[i].position, PatrolLocations[(i + 1) % PatrolLocations.Length].position);
            } 
        }
    }
}
