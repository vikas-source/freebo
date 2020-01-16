using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float jump = 100f;
    bool isgrounded;
    bool isdead = false;
    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D bc2d;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      if (isdead ==false)
       {
          

          if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(4f, 0f, 0f);
                anim.SetBool("isRun", true);
                sr.flipX = false;
            }

          if(Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector3(-4f, 0f, 0f);
                anim.SetBool("isRun", true);
                sr.flipX = true;
            }

          if(Input.GetKey(KeyCode.Space) && isgrounded == true)
            {
                rb.AddForce(Vector2.up * jump);
                anim.SetBool("isjump", true);
                anim.SetBool("isRun", false);
                isgrounded = false;
            }
       }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isgrounded = true;
    }
}
