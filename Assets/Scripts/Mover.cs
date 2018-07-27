using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Animator Anim;
    public float SpeedPlayer;

	// Use this for initialization
	void Start (){
	    rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity=new Vector2(horizontal,vertical)*SpeedPlayer;
        if (horizontal > 0)
        {
            Anim.SetInteger("walk", 4);
            Anim.speed = 0.5f;
        }
        else if (horizontal < 0)
        { 
	        Anim.SetInteger("walk", 3);
            Anim.speed = 0.5f;
        }
        

	    if (Input.GetKeyDown(KeyCode.W)){
            Anim.SetInteger("walk", 1);
            Anim.speed = 0.5f;
        }

	    if (Input.GetKeyDown(KeyCode.S)){
            Anim.SetInteger("walk", 2);
            Anim.speed = 0.5f;
        }
            
    }
}
