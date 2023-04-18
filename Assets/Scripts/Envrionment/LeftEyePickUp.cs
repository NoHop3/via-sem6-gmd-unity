using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftEyePickUp : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCrosshair;
    public GameObject LeftEye;
    public GameObject HalfFade;
    public GameObject EyeImg;
    public GameObject EyeText;
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ExtraCrosshair.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick up left eye";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCrosshair.SetActive(false);
                GlobalInventory.HasLeftEye = true;
                StartCoroutine(EyePicked());
            }
        }
    }

    void OnMouseExit()
    {
        ExtraCrosshair.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator EyePicked()
    {
        HalfFade.SetActive(true);
        EyeImg.SetActive(true);
        EyeText.SetActive(true);
        yield return new WaitForSeconds(3);
        HalfFade.SetActive(false);
        EyeImg.SetActive(false);
        EyeText.SetActive(false);
        LeftEye.SetActive(false);
    }
}
