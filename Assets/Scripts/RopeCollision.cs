using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollision : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Character player = collision.GetComponent<Character>();
            player.animator.SetBool(player.state, false);
            player.state = "OnRope";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Character player = collision.GetComponent<Character>();
            player.state = "";
            player.animator.SetBool("OnRope", false);
        }
    }
}
