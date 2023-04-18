using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinBreak : MonoBehaviour
{
    public GameObject FakePumpkin;
    public GameObject RealPumpkin;
    public GameObject SphereExplosion;
    public AudioSource PumpkinSmash;
    public GameObject KeyObject;
    public GameObject KeyPickUpTrig;
    void DamageZombie(int DamageAmount)
    {
        StartCoroutine(BreakPumpkin());
    }

    IEnumerator BreakPumpkin()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        PumpkinSmash.Play();
        KeyObject.SetActive(true);
        FakePumpkin.SetActive(false);
        RealPumpkin.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        SphereExplosion.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        SphereExplosion.SetActive(false);
        KeyPickUpTrig.SetActive(true);
    }
}
