using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class One__Opening : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    public GameObject ExtraCrosshair;
    void Start()
    {
        ExtraCrosshair.SetActive(false);
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<Text>().text = "I'm awake.... But where I am? I need to get out of here...";
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
