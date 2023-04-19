using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerWakeScript : MonoBehaviour
{
    void OnTriggerEnter()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        StalkerAI.StalkerActive = true;
    }
}
