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
        if (Input.GetButtonDown("Fire1") && GlobalAmmo.AmmoCount > 0)
        {
            if (isFiring == false)
            {
                GlobalAmmo.AmmoCount -= 1;
                StartCoroutine(FiringPistol());
            }
        }
    }

    IEnumerator FiringPistol()
    {
        RaycastHit Shot;
        isFiring = true;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("PistolShot", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }
        MuzzleFlash.SetActive(true);
        TheGun.GetComponent<Animation>().Play("PistolShotAnim");
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);
        MuzzleFlash.SetActive(false);
        isFiring = false;
    }
}
