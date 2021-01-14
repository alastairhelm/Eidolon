using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMazeControl : MonoBehaviour
{

    public List<GameObject> lavatiles;
    public PlayerControlable player;
  //  public List<bool> activeLava;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public  void lavaTrigger(int feed) {
        int stage = feed - 1;
      lavatiles[stage].SetActive(true);
        

    }

 
}
