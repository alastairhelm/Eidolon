using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int amount = 0;
    private int selected = 0;
    public PlayerControlable[] characters;
    public PlayerControlable player;
    private PlayerControlable currentPlayer = null;
    public Character charScript;
    public Item amulet;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = player;
        currentPlayer.playerControl(true);
        if(characters.Length != 1)
        {
            amount = characters.Length - 1;
        }
        else
        {
            amount = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       if (charScript.getInventory().Contains(amulet)){
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (characters.Length != 0)
                {
                    if (selected >= amount)
                    {
                        selected = 0;
                    }
                    else
                    {
                        selected = selected + 1;
                    }
                    currentPlayer.playerControl(false);
                    currentPlayer = characters[selected];
                    currentPlayer.playerControl(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                if (characters.Length != 0)
                {
                    currentPlayer.playerControl(false);
                    currentPlayer = player;
                    currentPlayer.playerControl(true);
                }
                Debug.Log(selected);
                Debug.Log(amount);
            }
        }
    }
    public PlayerControlable getCurrenlySelected()
    {
        return currentPlayer;
    }
}
