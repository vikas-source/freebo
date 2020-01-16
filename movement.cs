using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float jump;
    bool isgrounded;
    bool isdead;
    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D bc2d;
    SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      if (isdead ==false)
       {
            rb.velocity = new Vector3(0f, -1f, 0f);

          if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(1f, 0f, 0f);
                anim.SetBool("isRun", true);
            }

          if(Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector3(-1f, 0f, 0f);
                anim.SetBool("isRun", true);
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
}
