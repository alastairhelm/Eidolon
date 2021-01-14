using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform[] attackPosList;
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask whatIsEnemies;
    Animator animator;
    Transform attackPos;
    public float attackTime;

    private void Start()
    {
        attackTime = -1f;
        attackPos = attackPosList[3];
        animator = this.GetComponent<Animator>();
    }


    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //then the player can attack
            timeBtwAttack = startTimeBtwAttack;
            if (Input.GetKey(KeyCode.Space)) {                
                this.attackPos = getPlayerAttack();
                animator.SetTrigger("Attack");
                attackTime = 1f;
                resolveHits();
            } 
        } else if (attackTime >= 0) {
            resolveHits();
            attackTime -= Time.deltaTime;
        }

        else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private Transform getPlayerAttack() {
        Character player = this.GetComponent<Character>();

        if (player.lastReleased == "A") {
            return this.attackPosList[0];
        } else if (player.lastReleased == "W") {
            return this.attackPosList[1];
        } else if (player.lastReleased == "D") {
            return this.attackPosList[2];
        } else if (player.lastReleased == "S") {
            return this.attackPosList[3];
        }
        //Should not reach here
        return null;
    }

    private void resolveHits() {
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(this.attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, this.whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                if (enemiesToDamage.Length > 0)
                {
                    EnemyAi enemy = enemiesToDamage[i].GetComponent<EnemyAi>();
                    if (enemy != null) {
                        enemy.damage();
                    }
                }
            
        }
    }    
}
