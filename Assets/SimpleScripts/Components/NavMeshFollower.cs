using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshFollower : MonoBehaviour
{
    public enum PatrolType
    {
        Circle,
        Random
    }
    [Header("Path")]
    [SerializeField] private PatrolType patrolType;
    [SerializeField] private Transform[] pathPoints;
    [SerializeField] private float distanceReachingTarget = 1;

    [Header("View")]
    [SerializeField] private float viewDistance;

    [Header("Target")]
    [SerializeField] private Transform target;
    [SerializeField] private string findObjectTag = "Player";
    [SerializeField] private bool FindTargetOnStart;

    [Header("Action")]
    [SerializeField] private float actionDelay;
    public UnityEvent ActionWhenSee;

    private Vector3 targetPosition;
    private NavMeshAgent agent;
    private bool isSeeTarget;
    private float timer;
    private int pathIndex = 0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        if (FindTargetOnStart == true)
            target = GameObject.FindGameObjectWithTag(findObjectTag).transform;

        targetPosition = transform.position;

        if (patrolType == PatrolType.Random)
        {
            targetPosition = pathPoints[Random.Range(0, pathPoints.Length)].position;
        }


        if (patrolType == PatrolType.Circle)
        {
            targetPosition = pathPoints[0].position;
            pathIndex = 0;
        }

    }

    private void Update()
    {
        timer += Time.deltaTime;

        isSeeTarget = false;

        if (Vector3.Distance(transform.position, target.position) <= viewDistance)
        {
            
            RaycastHit raycastHit;

            if (Physics.Raycast(transform.position, (target.position - transform.position).normalized, out raycastHit, viewDistance))
            {
                if (raycastHit.collider.transform.root == target.root)
                    isSeeTarget = true;
            }

            if (isSeeTarget == true)
            {
                targetPosition = target.position;

                if (timer >= actionDelay)
                {
                    if (ActionWhenSee != null) ActionWhenSee.Invoke();

                    timer = 0;
                }
            }

           
        }

        if (isSeeTarget == false)
        {
            if (pathPoints != null)
            {
                if(patrolType == PatrolType.Random)
                {
                    if (Vector3.Distance(transform.position, targetPosition) <= distanceReachingTarget)
                    {
                        targetPosition = pathPoints[Random.Range(0, pathPoints.Length)].position;
                    }
                }

                if (patrolType == PatrolType.Circle)
                {
                    if (Vector3.Distance(transform.position, targetPosition) <= distanceReachingTarget)
                    {
                        pathIndex += 1;

                        if (pathIndex >= pathPoints.Length)
                            pathIndex = 0;

                        targetPosition = pathPoints[pathIndex].position;
                    }
                }
            }
        }

        agent.SetDestination(targetPosition);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (Vector3.Distance(transform.position, target.position) <= viewDistance)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.position);
        }

        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position + new Vector3(0, 1, 0), targetPosition);
        Gizmos.DrawCube(targetPosition, new Vector3(0.3f, 0.3f, 0.3f));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        
    }
#endif
}
