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


    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if(AttackTrigger == false)
        {
            EnemySpeed = 0.01f;
            TheEnemy.GetComponent<Animation>().Play("walk");
            transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
        }
        if(AttackTrigger == true)
        {
            EnemySpeed = 0;
            TheEnemy.GetComponent<Animation>().Stop("walk");
            if(IsAttacking == false)
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
        yield return new WaitForSeconds(2f);
        GlobalHealth.CurrentHealth -= 5;
        yield return new WaitForSeconds(0.2f);
        IsAttacking = false;
    }
}
