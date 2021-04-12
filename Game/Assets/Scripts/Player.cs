using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     Rigidbody2D rb;
    public float speed;
    
   // int currentHealthPoints; //текущее количество жизней

    //int maxHealthPoints = 5; //максимальное количество жизней

   // private bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // currentHealthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    /*void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (Input.GetAxis("Horizontal") < 0)
            
    }*/

    /*public void RecountHealthPoints(int deltaHP)
    {
        currentHealthPoints = currentHealthPoints + deltaHP;
        if (deltaHP < 0)
        {
            StartCoroutine(OnHit());
            isHit = true;
            StartCoroutine(OnHit());
        }
        //if (currentHealthPoints <= 0) можно сдлеать чтобы бесконечно падал вниз

    }

    IEnumerator OnHit()
    {
        if (isHit)
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g - 0.04f, GetComponent<SpriteRenderer>().color.b - 0.04f);
        else
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g + 0.04f, GetComponent<SpriteRenderer>().color.b + 0.04f);
        if (GetComponent<SpriteRenderer>().color.g == 1f)
            StopCoroutine(OnHit());
        if (GetComponent<SpriteRenderer>().color.g < 0)
            isHit = false
        yield return new WaitForSeconds(0.02f);
        StartCoroutine(OnHit());
        
    }*/
}
