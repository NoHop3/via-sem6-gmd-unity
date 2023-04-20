using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyePlaceTrig : MonoBehaviour
{
    public float TheDistance;
    public GameObject RealSphere;
    public GameObject FakeSphere;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCrosshair;
    public AudioSource WallMoveSound;
    public AudioSource RollEyeSound;
    public GameObject FakeWall;
    public GameObject RealWall;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ExtraCrosshair.SetActive(true);
            ActionText.GetComponent<Text>().text = "Place Eye in the sphere...";
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
                StartCoroutine(StartEyeEffect());
            }
        }
    }

    void OnMouseExit()
    {
        ExtraCrosshair.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator StartEyeEffect()
    {
        FakeSphere.SetActive(false);
        RealSphere.SetActive(true);
        RollEyeSound.Play();
        RealSphere.GetComponent<Animator>().Play("EyeRolling");
        yield return new WaitForSeconds(2);
        RealSphere.GetComponent<Animator>().Play("EyeHide");
        yield return new WaitForSeconds(0.5f);
        RealSphere.SetActive(false);
        RealWall.GetComponent<Animator>().Play("WallMove");
        WallMoveSound.Play();
        yield return new WaitForSeconds(1);
        RealWall.SetActive(false);
    }
}
