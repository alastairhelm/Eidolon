using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;
public class GhostAi : PlayerControlable
{
    Rigidbody2D body;
    public float movespeed;
    private Transform target;
    //Player
    public Character player;

    private float speed;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        // isSelected = false;
        target = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (isSelected)
        {
            Vector2 moveVector = new Vector2(horizontal, vertical);
            moveVector.Normalize();
            body.velocity = moveVector * movespeed;
        }
        else { 
            if(Vector2.Distance(body.position, target.position) >= 0.5f)
            {
                //body.position = Vector2.MoveTowards(body.position, target.position, movespeed * Time.deltaTime);
                Vector2 vector = Vector2.MoveTowards(body.position, target.position, movespeed * Time.deltaTime);
                
               // body.velocity = vector;
            }
            
        }
     
    }

}
