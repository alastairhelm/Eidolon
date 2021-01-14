using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poleBehavior : MonoBehaviour
{
    [SerializeField]
    Item item;

    [SerializeField]
    GameObject UI;

    [SerializeField]
    polePuzzleControl controller;

    public SpriteRenderer defaultPole;
    public SpriteRenderer correctPole;
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        defaultPole.enabled = true;
        correctPole.enabled = false;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated == false) {
            defaultPole.enabled =true;
            correctPole.enabled = false;
        } else {
            defaultPole.enabled = false;
            correctPole.enabled = true;
        } 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E) && this.item != null)
        {
            //blue, green, white, red = order
            Character player = collision.GetComponent<Character>();
            if(player.getInventory().Contains(this.item)){
                activated = true;
                controller.totemCheck();
            }
        }
        else if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.F) && this.item == null)
        {
            this.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

    }

    public bool getState() {

        return this.activated;
    }
}
