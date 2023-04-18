using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door1HingeOpen : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FadeOut;
    public GameObject ExtraCrosshair;
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            ExtraCrosshair.SetActive(true);
            ActionDisplay.SetActive(true);
            ActionText.GetComponent<Text>().text = "Open Door";
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(FadeToExit());
            }
        }
    }

    void OnMouseExit()
    {
        ExtraCrosshair.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator FadeToExit()
    {
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(5);
    }
}
