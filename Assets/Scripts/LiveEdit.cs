using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiveEdit : MonoBehaviour
{
  
    private int livesB4;
    private int livesaft;

    Color col;

 
    private float endTime = 0;

    private GameObject player;

    void Start()
    {
      
    }

    private void Update()
    {
        this.damagePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && endTime <= 0)
        {
            player = collision.gameObject;
            livesB4 = PlayerPrefs.GetInt("Lives");
            livesaft = livesB4 - 1;
            PlayerPrefs.SetInt("Lives", livesaft);
            endTime = 1;
            col = player.GetComponent<SpriteRenderer>().color;
            if (livesaft%4==0) {
                //checkpoint
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (this.player != null)
        {
            player.GetComponent<Character>().endTime = 0.2f;
        }

        
    }

    private void damagePlayer() {
        if (this.endTime > 0) {
            endTime -= Time.deltaTime;
        } 
    }

    
}
