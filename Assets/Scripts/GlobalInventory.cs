using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public static bool HasKey = false;
    public bool internalHasKey;
    void Update()
    {
        internalHasKey = HasKey;        
    }
}
