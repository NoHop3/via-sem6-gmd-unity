using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StalkerAI : MonoBehaviour
{
    public GameObject StalkerDest;
    NavMeshAgent NavAgent;
    Animator StalkerAnim;
    public GameObject Stalker;
    public static bool StalkerActive = false;
    public int StalkerHealth = 15;
    public bool AttackTrigger = false;
    public bool StalkerIsBeingHit = false;
    public bool StalkerIsHitting = false;
    public bool StalkerDead = false;

    // Animatior constants
    const string CROUCHED_WALKING = "Crouched Walking";
    const string MUTANT_IDLE = "Mutant Idle";
    const string HIT_REACTION = "Hit Reaction";
    const string MUTANT_DYING = "Mutant Dying";
    const string MUTANT_PUNCH = "Mutant Punch";
    const string MUTANT_FLEXING = "Mutant Flexing Muscles";

    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        StalkerAnim = Stalker.GetComponent<Animator>();
    }

    void PistolShot(int DamageAmount)
    {
        StartCoroutine(StalkerDamage());
    }

    void ChangeAnimationState(string newState)
    {
        StalkerAnim.Play(newState);
    }

    void Update()
    {
        if (StalkerIsBeingHit || StalkerIsHitting || StalkerDead || !StalkerActive)
        {
            NavAgent.SetDestination(transform.position);
        }
        if (StalkerActive && !StalkerDead && !StalkerIsBeingHit)
        {
            if (!AttackTrigger && !StalkerIsHitting)
            {
                // NavAgent.SetActive(true);
                NavAgent.SetDestination(StalkerDest.transform.position);
                ChangeAnimationState(CROUCHED_WALKING);
            }
            else
            {
                StartCoroutine(StalkerHit());
            }
        }
        else if (!StalkerActive && !StalkerIsBeingHit)
        {
            NavAgent.SetDestination(transform.position);
            ChangeAnimationState(MUTANT_IDLE);
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
        if (!StalkerDead)
        {
            StalkerIsBeingHit = true;
            StalkerHealth -= 5;
            ChangeAnimationState(HIT_REACTION);
            if (StalkerHealth <= 0)
            {
                StalkerDead = true;
                ChangeAnimationState(MUTANT_DYING);
                yield return new WaitForSeconds(4.6f);
                this.gameObject.GetComponent<Collider>().enabled = false;
                Stalker.SetActive(false);
            }
            else
            {
                yield return new WaitForSeconds(1.6f);
            }
            StalkerIsBeingHit = false;
        }
    }

    IEnumerator StalkerHit()
    {
        StalkerIsHitting = true;
        ChangeAnimationState(MUTANT_PUNCH);
        yield return new WaitForSeconds(1.1f);
        Debug.Log(GlobalHealth.CurrentHealth);
        // Fix stalekr dealing too much damage
        StalkerIsHitting = false;
        if (AttackTrigger)
        {
            GlobalHealth.CurrentHealth -= 0;
        }
    }
}
