using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // Physics stuff
    Rigidbody2D rigidbody2D;
    // target transformation
    private Transform target;
    //Player
    private Character player;
    // ai speed
    public float speed;
    private float startSpeed;
    // if player has been detected
    public bool playerDetection;

    //Death animation.
    private Animator anim;
    private float animTimer = 1;

    //player detection range
    public float detRange;

    //patrol route locations
    public Transform[] spots;
    private int ranSpot;

    //wait time for ai to move to next location
    private float waitTime;
    public float startWaitTime;

    //Pause time on hit
    public float dazedTime;
    public float startDazedTime;

    //Lenght of time between damaging
    public float timeTilDamage;
    public float startTimeTilDamage;

    //Health
    private int hitsTaken;
    private bool dead;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        player = FindObjectOfType<Character>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = player.GetComponent<Transform>();
        
        playerDetection = false;
        waitTime = startWaitTime;
        ranSpot = Random.Range(0, spots.Length);
        this.startSpeed = this.speed;
        this.hitsTaken = 0;
        this.dead = false;
        this.anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.dead)
        {
            if (playerDetection) // chase player if player has been detected
            {
                if (Vector2.Distance(rigidbody2D.position, target.position) > detRange)//if player is out of range
                {
                    playerDetection = false;
                }
                else
                { //move towards player
                    if (dazedTime <= 0)
                    {
                        this.speed = startSpeed;
                    }
                    else
                    {
                        this.speed = 0;
                        dazedTime -= Time.deltaTime;
                    }

                    Vector2 pos = rigidbody2D.position;

                    rigidbody2D.position = Vector2.MoveTowards(rigidbody2D.position, target.position, speed * Time.deltaTime);
                }

            }
            else if (spots.Length >= 0)
            { // patrol mode script

                if (Vector2.Distance(rigidbody2D.position, target.position) < detRange) // if player is in range
                {
                    Vector2 dirToTarget = rigidbody2D.position - new Vector2(target.position.x, target.position.y);
                    float angel = Vector2.Angle(transform.forward, dirToTarget);
                    if (Mathf.Abs(angel) < 90) // if player can be seen
                    {
                        playerDetection = true; // player is detected
                        return;
                    }
                }
                if(spots.Length > 0) { 
                rigidbody2D.position = Vector2.MoveTowards(rigidbody2D.position, spots[ranSpot].position, speed * Time.deltaTime);
                if (Vector2.Distance(rigidbody2D.position, spots[ranSpot].position) < 0.2f) // 
                {
                    if (waitTime <= 0)
                    {
                        ranSpot = Random.Range(0, spots.Length);

                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
            }
        }
        else {
            this.speed = 0;
            if (animTimer == 0) {
                this.anim.SetTrigger("dead");
            }
            if (animTimer > 0)
            {
                this.animTimer -= Time.deltaTime;
            }
            else { Destroy(this.gameObject); }
        }
    }

    //Resolve this enemy taking damage. if the enemy has already been damaged this attack then don't damage it.
    //if the enemy falls below its max health then destroy the object.
    public void damage() {
        dazedTime = startDazedTime;
        if (timeTilDamage <= 0) {
            hitsTaken++;
            timeTilDamage = startTimeTilDamage;
        }
        else {
            timeTilDamage -= Time.deltaTime;
        }


        if (this.hitsTaken == 1) {
            this.dead = true;
        }
    }


}