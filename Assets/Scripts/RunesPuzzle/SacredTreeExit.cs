using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SacredTreeExit : MonoBehaviour
{

    public polePuzzleControl poles;
    public int nextLevel;
    // Start is called before the first frame update
    void Start()
    {
       
           
        
    }

    // Update is called once per frame
    void Update()
    {
        if (poles.activatedTotems[0] == true && poles.activatedTotems[1] == true && poles.activatedTotems[2] == true && poles.activatedTotems[3] == true)
        {
            this.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (poles.activatedTotems[0] == true && poles.activatedTotems[1] == true && poles.activatedTotems[2] == true && poles.activatedTotems[3] == true)
        {
            if (collision.tag == "Player")
            {
                this.GetComponent<DialogueTrigger>().TriggerDialogue();
                PlayerPrefs.SetInt("Lives", 12);
                PlayerPrefs.SetInt("Carrot", 0);
                SceneManager.LoadScene(nextLevel);
            }
        }



    }
}
