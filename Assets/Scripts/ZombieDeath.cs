using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    
    public static int EnemyHealth = 20;
    public int ZombieHealth = 20;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource JumpScareSound;

    void DamageZombie(int DamageAmount)
    {
        if(StatusCheck == 0)
        {
            ZombieHealth -= DamageAmount;
            TheEnemy.GetComponent<Animation>().Play("gethit");
            TheEnemy.GetComponent<Animation>().PlayQueued("walk");
            EnemyHealth = ZombieHealth;
        }
    }

    void Update()
    {
        if(EnemyHealth <= 0 && StatusCheck == 0)
        {
            StatusCheck = 1;
            TheEnemy.GetComponent<Animation>().Stop("walk");
            TheEnemy.GetComponent<Animation>().Play("death2");
            JumpScareSound.Stop();
        }   
    }
}
