using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public int chestPieces;
    public Character player;
    private bool hasLadder;
    // Start is called before the first frame update
    void Start()
    {
        hasLadder = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Test");
        if (!hasLadder)
        {

            if (player.getInventory().Contains(FindObjectOfType<Ladder1>()) && player.getInventory().Contains(FindObjectOfType<Ladder2>()) && player.getInventory().Contains(FindObjectOfType<Ladder3>()) && player.getInventory().Contains(FindObjectOfType<Ladder1>()))
            {
                Debug.Log("WE HAVE ALL THE LADDERS");
                //popup message here
                this.GetComponent<DialogueTrigger>().TriggerDialogue();
                hasLadder = true;
            }
        }

    }
     public bool getLadder()
    {
        return hasLadder;
    }

}
