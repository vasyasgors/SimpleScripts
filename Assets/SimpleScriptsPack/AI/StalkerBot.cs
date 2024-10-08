﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class StalkerBot : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float viewDistance;
    [SerializeField] private string findObjectTag;

    [SerializeField] private float actionDelay;
    public UnityEvent ActionWhenSee;

    private Vector3 targetPosition;
    private NavMeshAgent agent;
    private bool isSeeTarget;
    private float timer;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        if (findObjectTag != "")
            target = GameObject.FindGameObjectWithTag(findObjectTag).transform;

        targetPosition = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) <= viewDistance)
        {
            RaycastHit[] hits = Physics.RaycastAll(transform.position, (target.position - transform.position).normalized);

            isSeeTarget = true;

            for(int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform != target)
                    isSeeTarget = false;
            }

            if (isSeeTarget == true)
            {
                targetPosition = target.position;

                if(timer >= actionDelay)
                {
                    if (ActionWhenSee != null) ActionWhenSee.Invoke();

                    timer = 0;
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

        Gizmos.DrawLine(transform.position, targetPosition);
        Gizmos.DrawCube(targetPosition, new Vector3(0.3f, 0.3f, 0.3f));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        
    }
#endif
}
