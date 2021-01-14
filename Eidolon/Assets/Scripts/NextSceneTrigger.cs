using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    public int nextLevel;
    public Item carrot;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && nextLevel != 5)
        {
            Character player = collision.GetComponent<Character>();
            int tru = 1;
            int fals = 0;
           

            SceneManager.LoadScene(nextLevel);



        }
        else if(collision.tag == "Player" && nextLevel == 5) {
            PlayerPrefs.SetInt("Lives", 12);
          
            SceneManager.LoadScene(nextLevel);
        }

       

    }

   

    
}
