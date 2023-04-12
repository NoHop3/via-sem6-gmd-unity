using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public AudioSource JumpscareMusic;
    public AudioSource DoorBang;
    public GameObject TheZombie;
    public GameObject TheDoor;
    public AudioSource AmbientMusic;

    void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        DoorBang.Play();
        TheDoor.GetComponent<Animation>().Play("JumpDoorAnim");
        TheZombie.SetActive(true);
        StartCoroutine(PlayJumpscareMusic());
    }

    IEnumerator PlayJumpscareMusic()
    {
        yield return new WaitForSeconds(0.5f);
        AmbientMusic.Pause();
        JumpscareMusic.Play();
    }
}
