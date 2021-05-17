using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest1 : MonoBehaviour
{
    public KeyCode action = KeyCode.O;
    public Player player;
    public GameObject LoseScreen;
    private string answer;

    public string GetAnswer()
    {
        return answer;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        
        if (/*collision.gameObject.tag == "Player" && */Input.GetKeyDown(action))
        {
            Time.timeScale = 0f;
            player.enabled = false;
       
            LoseScreen.SetActive(true);
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
