using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollide : MonoBehaviour
{
    public AudioSource ObjectCollideSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
        {
            ObjectCollideSound.Play();
        }
    }
}
