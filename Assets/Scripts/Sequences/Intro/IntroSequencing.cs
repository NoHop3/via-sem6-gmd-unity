using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSequencing : MonoBehaviour
{
    
    public GameObject TextBox;
    public GameObject DateDisplay;
    public GameObject PlaceDisplay;
    public AudioSource Line01;
    public AudioSource Line02;
    public AudioSource Line03;
    public AudioSource Line04;
    public AudioSource Line05;
    public AudioSource ThudSound;
    public GameObject AllBlack;

    void Start()
    {
        StartCoroutine(IntroBegin());
    }

    IEnumerator IntroBegin()
    {
        yield return new WaitForSeconds(3);
        PlaceDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        DateDisplay.SetActive(true);
        yield return new WaitForSeconds(4);
        TextBox.GetComponent<Text>().text = "The night of October 29th, 2008 changed me forever.";
        Line01.Play();
        yield return new WaitForSeconds(4.5f);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(3);
        TextBox.GetComponent<Text>().text = "I headed out to investigate the haunting sounds in the woods.";
        Line02.Play();
        yield return new WaitForSeconds(5);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(7);
        TextBox.GetComponent<Text>().text = "I stumbled upon a clearing with a cabin in the distance.";
        Line03.Play();
        yield return new WaitForSeconds(5);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(5);
        TextBox.GetComponent<Text>().text = "I could hear those sounds again coming from there.";
        Line04.Play();
        yield return new WaitForSeconds(4);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(5);
        TextBox.GetComponent<Text>().text = "Little did I know, that this was only the beginning.";
        Line05.Play();
        yield return new WaitForSeconds(5);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(35);
        AllBlack.SetActive(true);
        ThudSound.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
        yield return new WaitForSeconds(2);
    }
}
