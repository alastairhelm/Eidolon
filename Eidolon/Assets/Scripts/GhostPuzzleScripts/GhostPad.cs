using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPad : MonoBehaviour
{
    public GameObject platform;
    public GhostPad connectedPlatform;
    public BridgeControllerScript controller;
    public Vector3 cords;
    internal GameObject spawnobject;
    
    bool onPad;
    public bool ignore;
    void Start()
    {
        
        onPad = false;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("detect");

       if(collision.gameObject.tag == "Ghost" && !onPad)
        {
            //count++;
          
            
                controller.count++;
                onPad = true;
                Debug.Log("true");
                spawn();
            
            
        }

    }
    internal void spawn()
    {
        if (!ignore)
        {
            if (connectedPlatform != null) //if there is another platform requiured
            {
                if (connectedPlatform.onPad && onPad)// and pad is stepped on
                {
                    spawnobject = Instantiate(platform, cords, this.transform.rotation);// spawn pad
                }
            }
            else
            {
                spawnobject = Instantiate(platform, cords, this.transform.rotation);//spawn pad if no connected platform
            }
        }
        else
        {
            connectedPlatform.spawn();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ghost" && onPad)
        {
           
            onPad = false;
            Debug.Log("false");
            if (ignore)
            {
                controller.count--;
                Destroy(connectedPlatform.spawnobject);
            }
            else
            {
                controller.count--;
                Destroy(spawnobject);
            }
            
        }
       
        
    }
}
