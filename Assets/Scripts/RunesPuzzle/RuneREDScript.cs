using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneREDScript : MonoBehaviour
{
    public List<GameObject> enemies;
    public SpriteRenderer sr;
    public BoxCollider2D collide;
    

    [SerializeField]
    Item item;

    [SerializeField]
    GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        sr.enabled = false;
        collide.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies[0] == null) {
            sr.enabled = true;
            collide.enabled = true;
        }

  
    }
   
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E) && this.item != null && enemies[0] == null)
        {
            Character player = collision.GetComponent<Character>();
            player.addItem(this.item);
            item.GetComponent<DialogueTrigger>().TriggerDialogue();
            item.transform.parent.GetComponent<Animator>().SetBool("On", true);
            player.animator.SetBool(player.state, false);
            player.state = "PlayerReward";
            this.item = null;
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.F) && this.item == null)
        {
            this.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

    }
}
