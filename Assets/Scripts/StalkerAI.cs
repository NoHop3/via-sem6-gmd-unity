using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StalkerAI : MonoBehaviour
{
    public GameObject StalkerDest;
    NavMeshAgent NavAgent;
    public GameObject Stalker;
    public static bool StalkerActive = false;
    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (StalkerActive)
        {
            Stalker.GetComponent<Animator>().Play("Crouched Walking");
            NavAgent.SetDestination(StalkerDest.transform.position);
        }
    }
}
