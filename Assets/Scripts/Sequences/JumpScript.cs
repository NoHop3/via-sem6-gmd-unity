using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public AudioSource JumpscareMusic;
    public AudioSource DoorBang;
    public GameObject TheZombie;
    public GameObject TheDoor;

    void Start() {
        DoorBang.Play();
        TheDoor.GetComponent<Animation>().Play("JumpDoorAnim");
        TheZombie.SetActive(true);
        StartCoroutine(PlayJumpscareMusic());
    }

    // Add OnTriggerEnter() here

    IEnumerator PlayJumpscareMusic()
    {
        yield return new WaitForSeconds(0.5f);
        JumpscareMusic.Play();

    }
}
