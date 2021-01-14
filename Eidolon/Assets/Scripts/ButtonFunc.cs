using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunc : MonoBehaviour
{
    public Button button;

    [SerializeField]
    string function;

    // Start is called before the first frame update
    void Start()
    {
        Button b = button.GetComponent<Button>();
        b.onClick.AddListener(DoFunction);
    }

    void DoFunction() {
        if (this.function == "Start")
        {
            PlayerPrefs.SetInt("Lives", 12);
            PlayerPrefs.SetInt("Carrot", 0);
            SceneManager.LoadScene(sceneName: "Level_1");
           
        }
        else if (this.function == "Exit")
        {
            PlayerPrefs.SetInt("Lives", 12);
            PlayerPrefs.SetInt("Carrot", 0);
            Application.Quit();
        }
        
    }
    
}
