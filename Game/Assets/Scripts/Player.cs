using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpHeight;
    public Transform groundCheck;
    private bool isGrounded;
    private Animator anim;
    
    int currentHealthPoints; //текущее количество жизней

    int maxHealthPoints = 5; //максимальное количество жизней

    private bool isHit = false;

    private SpriteRenderer spriteRenderer;
    private IEnumerator _enumerator;

    // Start is called before the first frame update
    void Start()
    {
        _enumerator = OnHit();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
       currentHealthPoints = maxHealthPoints;
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        CheckGround();
        if (Input.GetAxis("Horizontal") == 0 && (isGrounded))
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            Flip();
            if (isGrounded)
                anim.SetInteger("State", 2);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;
        if (!isGrounded)
            anim.SetInteger("State", 3);
    }

    public void RecountHealthPoints(int deltaHP)
    {
        currentHealthPoints = currentHealthPoints + deltaHP;
        if (deltaHP < 0)
        {
            StopCoroutine(OnHit());
            isHit = true;
            StartCoroutine(OnHit());
        }
        //if (currentHealthPoints <= 0) можно сдлеать чтобы бесконечно падал вниз

    }

    IEnumerator OnHit()
    {
        if (isHit)
            spriteRenderer.color = new Color(spriteRenderer.color.r -10.2f , 255f, spriteRenderer.color.b - 10.2f);
        else
            spriteRenderer.color = new Color(spriteRenderer.color.r +10.2f, 255f, spriteRenderer.color.b +10.2f);
        if (spriteRenderer.color.r == 255f)
            StopCoroutine(_enumerator);
        if (spriteRenderer.color.r <= 0)
            isHit = false;
        yield return new WaitForSeconds(0.02f);
        StartCoroutine(_enumerator);
        
    }
}
