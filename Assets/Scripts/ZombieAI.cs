using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    Animator ZombieAnim;
    public GameObject ThePlayer;
    public GameObject Zombie;
    public bool AttackTrigger = false;
    public AudioSource Hurt1;
    public AudioSource Hurt2;
    public AudioSource Hurt3;
    public int RandomHurt;
    public GameObject TheFlash;
    public int ZombieHealth = 15;
    public bool ZombieIsBeingHit = false;
    public bool ZombieIsHitting = false;
    public bool ZombieDead = false;
    public AudioSource JumpScareSound;
    public AudioSource AmbientSound;

    // Animatior constants
    const string ZOMBIE_WALK = "walk";
    const string ZOMBIE_GET_HIT = "gethit";
    const string ZOMBIE_DEATH = "death2";
    const string ZOMBIE_ATTACK = "atack1";

    void Start()
    {
        ZombieAnim = Zombie.GetComponent<Animator>();
    }

    void PistolShot(int DamageAmount)
    {
        StartCoroutine(ZombieDamaged());
    }

    void ChangeAnimationState(string newState)
    {
        ZombieAnim.Play(newState);
    }

    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (ZombieIsBeingHit || ZombieIsHitting || ZombieDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, 0);
        }
        if (!ZombieIsBeingHit && !ZombieIsHitting && !ZombieDead)
        {
            if (!AttackTrigger)
            {
                ChangeAnimationState(ZOMBIE_WALK);
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, 0.02f);
            }
            else
            {
                StartCoroutine(InflictDamage());
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

    IEnumerator ZombieDamaged()
    {
        if (!ZombieDead)
        {
            ZombieIsBeingHit = true;
            ZombieHealth -= 5;
            ChangeAnimationState(ZOMBIE_GET_HIT);
            if (ZombieHealth <= 0)
            {
                JumpScareSound.Stop();
                ZombieDead = true;
                ChangeAnimationState(ZOMBIE_DEATH);
                yield return new WaitForSeconds(2.4f);
                this.gameObject.GetComponent<Collider>().enabled = false;
                AmbientSound.Play();
                Zombie.SetActive(false);
            }
            else
            {
                yield return new WaitForSeconds(1.5f);
            }
            ZombieIsBeingHit = false;
        }
    }

    IEnumerator InflictDamage()
    {
        if (AttackTrigger)
        {
            ZombieIsHitting = true;
            ChangeAnimationState(ZOMBIE_ATTACK);
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
            TheFlash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            TheFlash.SetActive(false);
            yield return new WaitForSeconds(2.3f);
            GlobalHealth.CurrentHealth -= 5;
            ZombieIsHitting = false;
        }
        else yield break;
    }
}
