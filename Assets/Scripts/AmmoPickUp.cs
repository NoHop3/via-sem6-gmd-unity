using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPickUp : MonoBehaviour
{
    public GameObject AmmoDisplayPanel;
    void OnTriggerEnter()
    {
        AmmoDisplayPanel.SetActive(true);
        GlobalAmmo.AmmoCount += 6;
        GameObject.Find("AmmoBox").SetActive(false);
    }
}
