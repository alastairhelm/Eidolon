using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILives : MonoBehaviour
{

    public GameObject[] Hearts;
    public GameObject gameOver;
    
    private void Start()
    {
      
    }

    private void Update()
    {

        int health = PlayerPrefs.GetInt("Lives");

        switch (health)
        {
          
//THIRD HEART
            case 12:
                heartFULL(Hearts[0]);
                heartFULL(Hearts[1]);
                heartFULL(Hearts[2]);
                break;
            case 11:
                heartFULL(Hearts[0]);
                heartFULL(Hearts[1]);
                heartTHREE(Hearts[2]);

                break;

            case 10:
                heartFULL(Hearts[0]);
                heartFULL(Hearts[1]);
                heartHALF(Hearts[2]);

                break;
            case 9:
                heartFULL(Hearts[0]);
                heartFULL(Hearts[1]);
                heartONE(Hearts[2]);

                break;
            case 8:
                heartFULL(Hearts[0]);
                heartFULL(Hearts[1]);
                heartNONE(Hearts[2]);
                
                break;

            //SECOND HEART
            case 7:
                heartFULL(Hearts[0]);
                heartTHREE(Hearts[1]);
                heartNONE(Hearts[2]);
                break;
            case 6:
                heartFULL(Hearts[0]);
                heartHALF(Hearts[1]);
                heartNONE(Hearts[2]);
                break;

            case 5:
                heartFULL(Hearts[0]);
                heartONE(Hearts[1]);
                heartNONE(Hearts[2]);
                break;
            case 4:
                heartFULL(Hearts[0]);
                heartNONE(Hearts[1]);
                heartNONE(Hearts[2]);
                break;
                //FIRST HEART
            case 3:
                heartTHREE(Hearts[0]);
                heartNONE(Hearts[1]);
                heartNONE(Hearts[2]);
                break;

            case 2:
                heartHALF(Hearts[0]);
                heartNONE(Hearts[1]);
                heartNONE(Hearts[2]);
                break;

            case 1:
                heartONE(Hearts[0]);
                heartNONE(Hearts[1]);
                heartNONE(Hearts[2]);
                break;

            case 0:
                heartNONE(Hearts[0]);
                heartNONE(Hearts[1]);
                heartNONE(Hearts[2]);

                gameOver.SetActive(true);
                //perma death
                SceneManager.LoadScene(sceneName: "StartScreen");
                break;

        }
    }

    public void heartFULL(GameObject heart) {
        GameObject full = heart.transform.GetChild(0).gameObject;
        GameObject threequart = heart.transform.GetChild(1).gameObject;
        GameObject half = heart.transform.GetChild(2).gameObject;
        GameObject onequart = heart.transform.GetChild(3).gameObject;
        full.SetActive(true);
        threequart.SetActive(false);
        half.SetActive(false);
        onequart.SetActive(false);

    }
    public void heartTHREE(GameObject heart)
    {
        GameObject full = heart.transform.GetChild(0).gameObject;
        GameObject threequart = heart.transform.GetChild(1).gameObject;
        GameObject half = heart.transform.GetChild(2).gameObject;
        GameObject onequart = heart.transform.GetChild(3).gameObject;
        full.SetActive(false);
        threequart.SetActive(true);
        half.SetActive(false);
        onequart.SetActive(false);

    }
    public void heartHALF(GameObject heart)
    {
        GameObject full = heart.transform.GetChild(0).gameObject;
        GameObject threequart = heart.transform.GetChild(1).gameObject;
        GameObject half = heart.transform.GetChild(2).gameObject;
        GameObject onequart = heart.transform.GetChild(3).gameObject;
        full.SetActive(false);
        threequart.SetActive(false);
        half.SetActive(true);
        onequart.SetActive(false);

    }
    public void heartONE(GameObject heart)
    {
        GameObject full = heart.transform.GetChild(0).gameObject;
        GameObject threequart = heart.transform.GetChild(1).gameObject;
        GameObject half = heart.transform.GetChild(2).gameObject;
        GameObject onequart = heart.transform.GetChild(3).gameObject;
        full.SetActive(false);
        threequart.SetActive(false);
        half.SetActive(false);
        onequart.SetActive(true);

    }
    public void heartNONE(GameObject heart)
    {
        GameObject full = heart.transform.GetChild(0).gameObject;
        GameObject threequart = heart.transform.GetChild(1).gameObject;
        GameObject half = heart.transform.GetChild(2).gameObject;
        GameObject onequart = heart.transform.GetChild(3).gameObject;
        full.SetActive(false);
        threequart.SetActive(false);
        half.SetActive(false);
        onequart.SetActive(false);


    }
}



