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
    public AudioSource Hurt1;
    public AudioSource Hurt2;
    public AudioSource Hurt3;
    public int RandomHurt;
    public GameObject TheFlash;

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
        if (StalkerActive && !StalkerDead && !StalkerIsBeingHit && !StalkerIsHitting)
        {
            if (!AttackTrigger)
            {
                NavAgent.SetDestination(StalkerDest.transform.position);
                ChangeAnimationState(CROUCHED_WALKING);
            }
            else
            {
                StartCoroutine(StalkerHit());
            }
        }
        else if (!StalkerActive && !StalkerIsBeingHit && !StalkerIsHitting)
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
        if(AttackTrigger)
        {
            StalkerIsHitting = true;
            ChangeAnimationState(MUTANT_PUNCH);
            RandomHurt = Random.Range(1, 4);
            switch (RandomHurt)
            {
                case 1:
                    Hurt1.Play();
                    break;
                case 2:
                    Hurt2.Play();
                    break;
                case 3:
                    Hurt3.Play();
                    break;
            }
            yield return new WaitForSeconds(1.1f);
            TheFlash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            TheFlash.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            GlobalHealth.CurrentHealth -= 5;
            yield return new WaitForSeconds(1f);
            StalkerIsHitting = false;
        }
        else yield break;
    }
}
