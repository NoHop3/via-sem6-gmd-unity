using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFuction : MonoBehaviour
{

    public GameObject fadeOut;
    public AudioSource buttonSound;
    public void NewGameButton()
    {
        StartCoroutine(NewGameStart());
    }
    
    IEnumerator NewGameStart()
    {
        fadeOut.SetActive(true);
        buttonSound.Play();
        fadeOut.GetComponent<Animation>().Play("FadeScreenOut");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(4);
    }
}
