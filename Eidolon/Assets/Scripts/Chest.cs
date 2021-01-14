using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    Item item;

    [SerializeField]
    GameObject UI;

    Animator chestOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        chestOpen = GetComponent<Animator>();
    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E) && this.item != null) {
            Character player = collision.GetComponent<Character>();
            chestOpen.SetBool("Opening", true);
            player.addItem(this.item);
            item.GetComponent<DialogueTrigger>().TriggerDialogue();
            item.transform.parent.GetComponent<Animator>().SetBool("On", true);
            player.animator.SetBool(player.state, false);
            player.state = "PlayerReward";
            this.item = null;
        } else if  (collision.tag == "Player" && Input.GetKeyDown(KeyCode.F) && this.item == null){
            this.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

    }
}
