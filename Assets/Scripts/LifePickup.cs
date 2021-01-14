using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            Character player = collision.GetComponent<Character>();
            player.animator.SetBool(player.state, false);
            player.state = "PlayerReward";

            int livesb4 = PlayerPrefs.GetInt("Lives");
            int livesaft = livesb4 + 1;
            if (livesaft <= 12) {
                PlayerPrefs.SetInt("Lives", livesaft);
            }

            Destroy(this.gameObject);
        }
       

    }
}
