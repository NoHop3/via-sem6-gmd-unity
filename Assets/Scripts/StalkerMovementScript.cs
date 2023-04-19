using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerMovementScript : MonoBehaviour
{
    // While staying in the trigger StalkerAI.StalkerActive is set to true
    void OnTriggerStay()
    {
        StalkerAI.StalkerActive = true;
    }

    void OnTriggerExit()
    {
        StalkerAI.StalkerActive = false;
    }
}
