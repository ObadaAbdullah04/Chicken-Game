using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tf1 : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    Rigidbody2D rb;
    bool OnGround;
    //SpriteRenderer sp;
    //Animator anim;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnGround=true;
    }

    // Update is called once per frame
    void Update()
    {
        float Ho = Input.GetAxis("Horizontal");
        transform.position += new Vector3(Ho * speed, 0, 0);
        if(Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            rb.AddForce(new Vector2(0 ,JumpForce));
        }     //anim.SetTrigger("jump");
        
        //Flip
       // if(Ho>0)
       // {
       //     sp.flipX=false;
       // }
       // else if(Ho<0)
      //  {
       //     sp.flipX=true;
      //  }
        //Animator
       // if(Ho!=0)
      //  {
      //      anim.SetBool("idle_walk",true);
      //  }
      //  else
      //  {
      //       anim.SetBool("idle_walk",false);
      //  }
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
        OnGround=true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
         if(collision.gameObject.tag == "Ground")
        {
        OnGround=false;
        }
    }
}    