using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSpawner : MonoBehaviour
{
    public ChestController controller;
    public Ladder ladder;
    public Vector3 tran;
    public Quaternion rot;
    public GameObject blocker;
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Here");
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Here");
            if (controller.getLadder())
            {
                Debug.Log("spawn bridge");
                // insert popup deploying ladder

                Instantiate(ladder, tran, rot);
                Destroy(blocker);
            }
            else
            {
                this.GetComponent<DialogueTrigger>().TriggerDialogue();
                //insert popup "dont have all pieces"
            }
        }
    }
        

}
 
