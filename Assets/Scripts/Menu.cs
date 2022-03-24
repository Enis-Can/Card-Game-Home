using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MMenu;
    public GameObject Options;


    public void playGame()
    {
        SceneManager.LoadScene("Stages");
    }
    public void options()
    {
        MMenu.SetActive(false);
        Options.SetActive(true);
    }

    public void back()
    {
        MMenu.SetActive(true);
        Options.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
