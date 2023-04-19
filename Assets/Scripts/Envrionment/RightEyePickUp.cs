using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightEyePickUp : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCrosshair;
    public GameObject RightEye;
    public GameObject HalfFade;
    public GameObject EyeImg;
    public GameObject EyeText;
    public GameObject FakeWall;
    public GameObject RealWall;
    public GameObject RealWallCandle;
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ExtraCrosshair.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick up right eye";
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
                GlobalInventory.HasRightEye = true;
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
        EyeText.GetComponent<Text>().text = "You got the right eye piece!";
        EyeText.SetActive(true);
        yield return new WaitForSeconds(3);
        HalfFade.SetActive(false);
        EyeImg.SetActive(false);
        EyeText.SetActive(false);
        RightEye.SetActive(false);
        FakeWall.SetActive(false);
        RealWall.SetActive(true);
        RealWallCandle.SetActive(true);
    }
}
