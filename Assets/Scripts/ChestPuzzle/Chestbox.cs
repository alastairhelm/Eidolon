using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chestbox : MonoBehaviour

{
    public bool isTrap;//toggle for chest - enables trap spawn if true
    public int numberOfEnemies;
    public float enemyDistance; // spawn distance for enemys
    [SerializeField]
    public Item item;
    public bool isStarter;

    public EnemyAi enemy;
    Animator chestOpen;
    void Start()
    {
        chestOpen = GetComponent<Animator>();
    }
    /// <summary>
    /// This method handles what happens if player interacts with chest
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            if (isStarter)
            {
                this.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
            Debug.Log("hi");
            if (isTrap)
            {
                spawnHostiles();
            }
            else if(this.item != null)
            {
                Character player = collision.GetComponent<Character>();
                chestOpen.SetBool("Opening", true);
                player.addItem(this.item);
                item.GetComponent<DialogueTrigger>().TriggerDialogue();
                item.transform.parent.GetComponent<Animator>().SetBool("On", true);
                player.animator.SetBool(player.state, false);
                player.state = "PlayerReward";
                this.item = null;
            }
        }
    }
    /// <summary>
    /// Script for spawning hostiles. Script will take number from numberofhostiles global
    /// parameter and random spawn enemies in room.
    /// </summary>
    private void spawnHostiles()
    {
        chestOpen.SetBool("Opening", true);
        System.Random rnd = new System.Random();
        float rand;
        for(int i = 0; i < numberOfEnemies; i++)
        {

            


            Instantiate(enemy, new Vector3(this.transform.position.x + UnityEngine.Random.Range(-enemyDistance,enemyDistance) , this.transform.position.y + UnityEngine.Random.Range(-enemyDistance, enemyDistance), this.transform.position.z - 1), this.transform.rotation);// random spawn enemy
        }
        
    }
}
