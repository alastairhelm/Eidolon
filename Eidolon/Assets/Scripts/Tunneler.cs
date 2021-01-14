using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunneler : MonoBehaviour
{ 
    [SerializeField]
    public Tunneler target;

    

    bool on = true;

    


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && this.on) {
            target.on = false;
            collider.transform.position = new Vector3(this.target.transform.position.x, this.target.transform.position.y, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            this.on = true;
        }
    }
}
