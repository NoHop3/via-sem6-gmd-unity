using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int ZombieHealth = 20;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource JumpScareSound;
    public AudioSource AmbientSound;

    void DamageZombie(int DamageAmount)
    {
        if (StatusCheck == 0)
        {
            ZombieHealth -= DamageAmount;
            TheEnemy.GetComponent<Animation>().Play("gethit");
            TheEnemy.GetComponent<Animation>().PlayQueued("walk");
        }
    }

    void Update()
    {
        if (ZombieHealth <= 0 && StatusCheck == 0)
        {
            StatusCheck = 1;
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            TheEnemy.GetComponent<Animation>().Stop("walk");
            TheEnemy.GetComponent<Animation>().Play("death2");
            JumpScareSound.Stop();
            AmbientSound.Play();
        }
    }
}
