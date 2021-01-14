//using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;
public class Character : PlayerControlable
{
    List<Item> inventory;
    Rigidbody2D body;
    public Animator animator;
    public string state;

    //private bool isSelected = false;
    float horizontal;
    float vertical;
    public float moveSpeed;
    public string lastReleased;

    public float time;
    private float timer;
    private bool timerActive = false;
    public Light2D lightComp = null;
    public GameObject l;
    public Carrot carrot;
    
      public float ogLightinOuter;
    public float carrotLightinOuter;

    public float endTime = 0;
    private Color col;

    private GameMaster gm;
    void Start()
    {

        inventory = new List<Item>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("IsIdleDown", true);
        state = "IsIdleDown";

        // checkpoint code
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        // light code
        lightComp = l.GetComponent<Light2D>();
        lightComp.pointLightOuterRadius = ogLightinOuter;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (this.state == "PlayerReward")
            {
                if (!animator.GetBool("PlayerReward"))
                {
                    animator.SetBool("PlayerReward", true);
                }
                else
                {
                    animator.SetBool("PlayerReward", false);
                    this.state = "IsIdleDown";
                    animator.SetBool("IsIdleDown", true);
                }
            }
            else if (this.state == "OnRope")
            {
                if (!animator.GetBool("OnRope"))
                {
                    animator.SetBool("OnRope", true);
                }

            }
            else
            {
                resolveMoveAnimation();
            }



            if (timerActive == true)
            {
                if (timer <= 0)
                {
                    timerActive = false;
                    lightComp.pointLightOuterRadius = ogLightinOuter;
                    getInventory().Remove(carrot);
                }
                else
                {
                  float scaler = timer/time;
                  lightComp.pointLightOuterRadius = ogLightinOuter + ((carrotLightinOuter - ogLightinOuter)* scaler);
                  timer -= Time.deltaTime;
                
                }
            }
            else
            {
                updateSize();

            }
        }
        takeHit();
    }

    void updateSize()
    {
        if (getInventory().Contains(carrot))
        {
            lightComp.pointLightOuterRadius = carrotLightinOuter;
            timerActive = true;
            timer = time;
        }
    }
    private void FixedUpdate()
    {
        Vector2 moveVector = new Vector2(horizontal, vertical);
        moveVector.Normalize();
        body.velocity = moveVector * moveSpeed;
    }

    public void addItem(Item item)
    {
        inventory.Add(item);
    }

    public List<Item> getInventory()
    {
        return this.inventory;
    }

    private void resolveMoveAnimation()
    {
        if (body.velocity == Vector2.zero && (state != "IsIdleDown" || state != "IsIdleLeft" || state != "IsIdleRight" || state != "IsIdleUp") && !Input.anyKey)
        {
            animator.SetBool(state, false);
            if (lastReleased == "A")
            {
                animator.SetBool("IsIdleLeft", true);
                this.state = "IsIdleLeft";
            }
            else if (lastReleased == "D")
            {
                animator.SetBool("IsIdleRight", true);
                this.state = "IsIdleRight";
            }
            else if (lastReleased == "S")
            {
                animator.SetBool("IsIdleDown", true);
                this.state = "IsIdleDown";
            }
            else if (lastReleased == "W")
            {
                animator.SetBool("IsIdleUp", true);
                this.state = "IsIdleUp";
            }
        }

        else if ((horizontal < 0 && state != "MoveLeft") || Input.GetKeyDown(KeyCode.A))
        {
            lastReleased = "A";
            animator.SetBool(state, false);
            animator.SetBool("MoveLeft", true);
            this.state = "MoveLeft";
        }
        else if ((horizontal > 0 && state != "MoveRight") || Input.GetKeyDown(KeyCode.D))
        {
            lastReleased = "D";
            animator.SetBool(state, false);
            animator.SetBool("MoveRight", true);
            this.state = "MoveRight";
        }
        else if ((vertical > 0 && horizontal == 0 && state != "MoveUp") || Input.GetKeyDown(KeyCode.W))
        {
            lastReleased = "W";
            animator.SetBool(state, false);
            animator.SetBool("MoveUp", true);
            this.state = "MoveUp";
        }
        else if ((vertical < 0 && horizontal == 0 && state != "MoveDown") || Input.GetKeyDown(KeyCode.S))
        {
            lastReleased = "S";
            animator.SetBool(state, false);
            animator.SetBool("MoveDown", true);
            this.state = "MoveDown";
        }
    }
    //public void playerControl(bool var)
    //{
    //    isSelected = var;
    //}

    public void takeHit()
    {
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        if (endTime > 0)
        {
            sprite.color = Color.red;
        }
        else if (endTime <= 0)
        {
            sprite.color = Color.white;
        }
        endTime -= Time.deltaTime;
    }

}
