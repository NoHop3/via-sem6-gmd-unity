using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalHealth : MonoBehaviour
{
    public static int CurrentHealth = 20;
    public int InternalHealth;
    
    void Update()
    {
        InternalHealth = CurrentHealth;
    }
}
