﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollectScript : MonoBehaviour
{
    [SerializeField]
    Item item;

    [SerializeField]
    GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E) && this.item != null)
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