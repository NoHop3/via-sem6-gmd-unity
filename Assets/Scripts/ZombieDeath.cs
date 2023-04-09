using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    
    public int EnemyHealth = 20;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource JumpScareSound;

    void DamageZombie(int DamageAmount)
    {
        if(StatusCheck == 0)
        {
            EnemyHealth -= DamageAmount;
            TheEnemy.GetComponent<Animation>().Play("gethit");
            TheEnemy.GetComponent<Animation>().PlayQueued("walk");
        }
    }

    void Update()
    {
        if(EnemyHealth <= 0 && StatusCheck == 0)
        {
            StatusCheck = 2;
            TheEnemy.GetComponent<Animation>().Stop("walk");
            TheEnemy.GetComponent<Animation>().Play("death2");
            StartCoroutine(KillEnemy());
        }   
    }

    IEnumerator KillEnemy()
    {
        TheEnemy.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(4f);
        JumpScareSound.Stop();
    }
}
