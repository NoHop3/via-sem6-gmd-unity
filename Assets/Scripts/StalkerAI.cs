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
    public int StalkerHealth = 30;
    public bool AttackTrigger = false;
    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
    }

    void PistolShot(int DamageAmount)
    {
        StartCoroutine(StalkerDamage());
    }

    void Update()
    {
        if (StalkerActive)
        {
            if (AttackTrigger == false && StalkerHealth > 0)
            {
                NavAgent.SetDestination(StalkerDest.transform.position);
                Stalker.GetComponent<Animator>().Play("Crouched Walking");
            }
            if(AttackTrigger == true && StalkerHealth > 0)
            {
                StartCoroutine(StalkerHit());
            }
        }
    }

    void OnTriggerEnter()
    {
        AttackTrigger = true;
    }

    void OnTriggerExit()
    {
        AttackTrigger = false;
    }

    IEnumerator StalkerDamage()
    {
        StalkerHealth -= 5;
        
        Stalker.GetComponent<Animator>().Play("Hit Reaction");
        yield return new WaitForSeconds(1.6f);
        if (StalkerHealth <= 0)
        {
            Stalker.GetComponent<BoxCollider>().enabled = false;
            Stalker.GetComponent<Animator>().Play("Mutant Dying");
            yield return new WaitForSeconds(4.6f);
            StalkerActive = false;
            Stalker.SetActive(false);
        }
    }

    IEnumerator StalkerHit()
    {
        
        Stalker.GetComponent<Animator>().Play("Mutant Punch");
        yield return new WaitForSeconds(1.1f);
        GlobalHealth.CurrentHealth -= 0;
    }
}
