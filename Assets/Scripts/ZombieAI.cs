using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TheEnemy;
    public float EnemySpeed = 0.01f;
    public bool AttackTrigger = false;
    public bool IsAttacking = false;
    public AudioSource Hurt1;
    public AudioSource Hurt2;
    public AudioSource Hurt3;
    public int RandomHurt;


    void Update()
    {
            transform.LookAt(ThePlayer.transform);
            if (AttackTrigger == false)
            {
                EnemySpeed = 0.01f;
                TheEnemy.GetComponent<Animation>().Play("walk");
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
            }
            if (AttackTrigger == true)
            {
                EnemySpeed = 0;
                TheEnemy.GetComponent<Animation>().Stop("walk");
                if (IsAttacking == false)
                {
                    TheEnemy.GetComponent<Animation>().Play("atack1");
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

    IEnumerator InflictDamage()
    {
        IsAttacking = true;
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
        yield return new WaitForSeconds(1.5f);
        GlobalHealth.CurrentHealth -= 5;
        yield return new WaitForSeconds(1f);
        IsAttacking = false;
    }
}
