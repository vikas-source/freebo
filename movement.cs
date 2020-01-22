using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float jump ;
    bool isdead = false;
    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D bc2d;
    SpriteRenderer sr;
    //GroundCheck 
    private bool isgrounded;
    public Transform groundcheck;
    public float radiuscheck;
    public LayerMask whatisgrounded;
    //Extra Jumps
    private int extraJumps;
    public int extraJumpValue;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        extraJumps = extraJumpValue;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, radiuscheck, whatisgrounded);

        //Move right >>
        if (Input.GetKey(KeyCode.D))
        {
            sr.flipX = false;
            rb.velocity = new Vector3(1.2f, 0f, 0f);
            anim.SetBool("isRun", true);
        }

        //Move left <<
        if (Input.GetKey(KeyCode.A))
        {
            sr.flipX = true;
            rb.velocity = new Vector3(-1.2f, 0f, 0f);
            anim.SetBool("isRun", true);
        }


    }
    void Update()
    { 
      if (isdead ==false)
       {  
            if(isgrounded == true)
            {
                extraJumps = extraJumpValue;
            }

            if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
            {
                rb.AddForce(Vector2.up * jump);
                extraJumps--;
                anim.SetBool("isjump", true);
                anim.SetBool("isRun", false);
                isgrounded = false;
            }
            else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isgrounded == true)
            {
                rb.AddForce(Vector2.up * jump);
            }
            
            // Idle condition
            if (Input.anyKey == false)
            {
                anim.SetBool("isRun", false);
                anim.SetBool("isjump", false);
             }
          
       }
      
    }


    
}
