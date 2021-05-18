using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Chest1 : MonoBehaviour
{
    public KeyCode action = KeyCode.O;
    public Player player; 
    public GameObject QuestionPanel;
    public string answer;
    public bool isClosed;

    public string GetAnswer()
    {
        return answer;
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
