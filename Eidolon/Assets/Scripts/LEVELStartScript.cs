using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LEVELStartScript : MonoBehaviour
{
    
    GameMaster gm;
    public Vector2 lvlstart;
    public Character player;
    public Item carrot;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Lives") == 12 || PlayerPrefs.GetInt("Lives") == 1 ||SceneManager.GetActiveScene().buildIndex == 4)
        {
            gm = FindObjectOfType<GameMaster>();
            gm.lastCheckPointPos = lvlstart;
        }
      //  this.gameObject.SetActive(false);
      

    }


}
