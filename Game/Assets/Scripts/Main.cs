using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Player player;
    public Text textHearts;
    public GameObject PauseScreen;
    public GameObject WinScreen;
    public InputField input;
    public GameObject enterPanel;
    public Chest1 chest;
    
    public void CheckAnswer()
    {
        if (input.text == chest.GetAnswer())
        {
            ;
        }
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        textHearts.text = player.GetHearts().ToString();
    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        PauseScreen.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        PauseScreen.SetActive(false);
    }

    public void Win()
    {
        Time.timeScale = 0f;
        player.enabled = false;
       
        WinScreen.SetActive(true);
    }
    

    public void Menu()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
