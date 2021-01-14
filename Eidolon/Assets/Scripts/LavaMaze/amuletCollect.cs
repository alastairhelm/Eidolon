using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amuletCollect : MonoBehaviour
{
    [SerializeField]
    Item item;

    [SerializeField]
    GameObject UI;

    public LavaMazeControl controller;
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
            controller.lavaTrigger(1);

            Destroy(this.gameObject);

        }
      

    }
}
