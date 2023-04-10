using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public AudioSource GunFire;
    public bool isFiring = false;
    public float TargetDistance;
    public int DamageAmount = 5;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(isFiring == false)
            {
                StartCoroutine(FiringPistol());
            }
        }
    }

    IEnumerator FiringPistol()
    {
        RaycastHit Shot;
        isFiring = true;
        if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }
        TheGun.GetComponent<Animation>().Play("PistolShotAnim");
        TheGun.GetComponent<Animation>().Play("MuzzleAnim");
        MuzzleFlash.SetActive(true);
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);
        MuzzleFlash.SetActive(false);
        isFiring = false;
    }
}
