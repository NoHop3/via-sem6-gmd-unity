using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGameScript : MonoBehaviour
{
    public GameObject fadeOut;
    void OnTriggerEnter()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animation>().Play("FadeScreenOut");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(6);
    }
}
