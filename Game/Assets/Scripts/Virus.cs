using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    //когда объекты сталкиваются
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().RecountHealthPoints(-1);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 8f, ForceMode2D.Impulse);

        }
    }
    /*//когда соприкасаются
    void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    //когда прекращается соприкосновение
    void OnCollisionExit2D(Collision2D collision)
    {
        
    }*/
}
