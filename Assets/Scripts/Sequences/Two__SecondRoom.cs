using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Two__SecondRoom : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject TheMarker;

    void Start()
    {
        TheMarker.SetActive(false);
    }
    
    void OnTriggerEnter()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = "Hmm... There seems to be something on the table there...";
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        TheMarker.SetActive(true);
    }
}

