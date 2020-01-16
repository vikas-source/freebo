using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    float xpos;
    float xmove;
    
    Rigidbody2D rb;
    Animator anim;
    [SerializeField]
    AnimationCurve moveCurve;

    //Grounded 
    bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
            rb.AddForce(Vector2.up * jump);
            anim.SetBool("isjump", true);
            anim.SetBool("isRun", false);
            isGrounded = false;

        }

        

        xpos = Input.GetAxis("Horizontal");
        
        
            rb.velocity = new Vector2(xpos * speed /* * moveCurve.Evaluate(Time.deltaTime) */, 0f);
            anim.SetBool("isRun", true);
            anim.SetBool("isjump", false);


        if (Input.anyKey == false)
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isjump", false);
        }
        //if (xpos == 0)
        // {

        //  anim.SetBool("isRun", false);

        //}


    }
    //Check if Grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    
}