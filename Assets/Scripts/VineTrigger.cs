using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineTrigger : MonoBehaviour
{

    public RopeCollision rope;
    public BoxCollider2D playerOnly; 
    // Start is called before the first frame update
    void Start()
    {
        this.rope.GetComponent<BoxCollider2D>().enabled = false;
        this.playerOnly.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject block = collision.gameObject;
        if (block.GetComponent<VineBlock>() != null) {
            block.GetComponent<VineBlock>().inPos();
            this.rope.GetComponent<BoxCollider2D>().enabled = true;
            this.playerOnly.enabled = false;
        }
    }
}
