using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Chest1 : MonoBehaviour
{
    public KeyCode action = KeyCode.O;
    public Player player; 
    public GameObject QuestionPanel;
    public string answer1;
    public string answer2;
    public bool isClosed;
    public InputField input;
    public GameObject WinPanel;
    
    public GameObject LosePanel;
    public Chest1 chest;
    
    public void ClosePanel()
    {
        WinPanel.SetActive(false); 
        LosePanel.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        
        
        
    }
    public void CheckAnswer()
    {
        if (input.text.ToLower() == answer1 || input.text.ToLower() == answer2)
        {
            player.RecountHealthPoints(+1);
            QuestionPanel.SetActive(false);
            WinPanel.SetActive(true);
        }
        else
        {
            QuestionPanel.SetActive(false);
            LosePanel.SetActive(true);
        }
        Destroy(chest.gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && !isClosed)
        {
            Time.timeScale = 0f;
            player.enabled = false;
       
            QuestionPanel.SetActive(true);
            isClosed = true;
        }
        
        //Destroy(collision.gameObject);
            
    }
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
