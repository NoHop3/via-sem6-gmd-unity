using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFuction : MonoBehaviour
{

    public GameObject fadeOut;
    public AudioSource buttonSound;
    public GameObject LoadButton;
    public int LoadInt;
    void Start()
    {
        fadeOut.SetActive(false);
        LoadInt = PlayerPrefs.GetInt("AutoSave");
        if (LoadInt > 0)
        {
            LoadButton.SetActive(true);
        }
    }
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

    public void LoadGameButton()
    {
        StartCoroutine(LoadGameStart());
    }

    IEnumerator LoadGameStart()
    {
        fadeOut.SetActive(true);
        buttonSound.Play();
        fadeOut.GetComponent<Animation>().Play("FadeScreenOut");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(LoadInt);
    }

    public void QuitGameButton()
    {
        StartCoroutine(QuitGameStart());
    }

    IEnumerator QuitGameStart()
    {
        fadeOut.SetActive(true);
        buttonSound.Play();
        fadeOut.GetComponent<Animation>().Play("FadeScreenOut");
        yield return new WaitForSeconds(3);
        Application.Quit();
    }

    //! This is for the options menu, but I'm not using it right now.
    // public void OptionsButton()
    // {
    //     StartCoroutine(OptionsStart());
    // }

    // IEnumerator OptionsStart()
    // {
    //     fadeOut.SetActive(true);
    //     buttonSound.Play();
    //     fadeOut.GetComponent<Animation>().Play("FadeScreenOut");
    //     yield return new WaitForSeconds(3);
    //     SceneManager.LoadScene(1);
    // }

    public void CreditsButton()
    {
        StartCoroutine(CreditsStart());
    }

    IEnumerator CreditsStart()
    {
        fadeOut.SetActive(true);
        buttonSound.Play();
        fadeOut.GetComponent<Animation>().Play("FadeScreenOut");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(6);
    }

    public void GithubButton()
    {
        Application.OpenURL("https://github.com/NoHop3");
    }

    public void PortfolioButton()
    {
        Application.OpenURL("https://stgdev.netlify.app/");
    }

    public void TutorialButton()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=fSTQoClEAEQ&list=PLI5KGtDrj4HVInyXdx5N2oYUAb9U7rJ4L&index=78&ab_channel=JasonWeimann");
    }
}
