using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    [SerializeField]
    Transform finalLocation;

    [SerializeField]
    Waterfall waterfall;

    [SerializeField]
    Item glove;

    bool active = true;

    private float animTimer = 0.9f;
    private bool destroyed = false;

    //Freeze the boulder when the game starts, that way the player cannot move it
    void Start()
    {
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, finalLocation.position) < 0.45 && active) {
            this.active = false;
            finalLocation.transform.position = new Vector3(finalLocation.transform.position.x + 0.2f, finalLocation.transform.position.y, 0);
            waterfall.move();
            this.destroyed = true;
            
        }
        if (destroyed) {
                this.GetComponent<Animator>().SetBool("pushed", true);           
                Destroy(this.GetComponent<Rigidbody2D>());
                Destroy(this.GetComponent<CircleCollider2D>());
            
        }
        if (waterfall.currentTile >= 3)
        {
            
            Destroy(finalLocation.GetComponent<BoxCollider2D>());
        }
    }

    //Handle collision with the player, only allow the player to move the Rigidbody if they have the glove, else stay still
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            Character player = collision.gameObject.GetComponent<Character>();
            if (player.getInventory().Contains(this.glove))
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            }
        } 
    }

    //For when the player inspects the boulder
    private void OnTriggerStay2D (Collider2D collider){
        if (collider.tag == "Player" && Input.GetKeyDown(KeyCode.F)) {
            this.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

    //When the player stops pushing the boulder, stop it moving
    private void OnCollisionExit2D(Collision2D collision)
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }


}
