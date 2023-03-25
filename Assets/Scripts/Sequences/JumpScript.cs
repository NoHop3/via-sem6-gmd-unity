using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public AudioSource JumpscareMusic;
    public AudioSource DoorBang;
    public GameObject TheZombie;
    public GameObject TheDoor;

    void onTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("JumpDoorAnim");
        DoorBang.Play();
        TheZombie.SetActive(true);
        StartCoroutine(PlayJumpscareMusic());
    }

    IEnumerator PlayJumpscareMusic()
    {
        yield return new WaitForSeconds(0.5f);
        JumpscareMusic.Play();

    }
}
