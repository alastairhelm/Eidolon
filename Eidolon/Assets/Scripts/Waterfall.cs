using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Waterfall : MonoBehaviour {

    
    [SerializeField]
    public int currentX;

    public int currentTile = 0;
    // Use this for initialization
    

    

    public void move() { 
        currentTile++;
        currentX++;
    }
}
