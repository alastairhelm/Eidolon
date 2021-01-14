using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerScript : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Destroy()
    {
        Debug.Log("Bloker Removed");
        Destroy(this.gameObject);
    }
}
