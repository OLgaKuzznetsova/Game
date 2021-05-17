using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Main main;
    public Sprite finishSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.eulerAngles = new Vector3(0,0,90);
            //GetComponent<SpriteRenderer>().sprite = finishSprite;
            main.Win();
        }
    }
}
