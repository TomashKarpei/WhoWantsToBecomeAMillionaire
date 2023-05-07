using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuGlowne : MonoBehaviour
{
    public GameObject mm;
    public GameObject lista;
    public GameObject pomoc;

    private void Start()
    {
        mm.SetActive(true);
    }

    public void ListaTematow()
    {
        mm.SetActive(false);
        lista.SetActive(true);
    }

    public void pomocMenu()
    {
        mm.SetActive(false);
        pomoc.SetActive(true);
    }

    public void returnToMenu()
    {
        lista.SetActive(false);
        pomoc.SetActive(false);
        mm.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    //JAVA
    public void LoadLvl1()
    {
        SceneManager.LoadScene(1);
    }

    //c++
    public void LoadLvl2()
    {
        SceneManager.LoadScene(2);
    }

    //python
    public void LoadLvl3()
    {
        SceneManager.LoadScene(3);
    }

    //html
    public void LoadLvl4()
    {
        SceneManager.LoadScene(4);
    }

    //php
    public void LoadLvl5()
    {
        SceneManager.LoadScene(5);
    }



}
