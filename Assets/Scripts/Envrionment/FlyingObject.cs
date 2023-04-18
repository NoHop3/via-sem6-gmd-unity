using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    public GameObject SphereFlyingObject;

    void OnTriggerEnter()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        SphereFlyingObject.SetActive(true);
        StartCoroutine(SphereRemove());
    }

    IEnumerator SphereRemove()
    {
        yield return new WaitForSeconds(3);
        SphereFlyingObject.SetActive(false);
    }
}
