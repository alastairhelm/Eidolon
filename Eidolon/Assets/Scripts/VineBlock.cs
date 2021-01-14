using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineBlock : MonoBehaviour
{
    Rigidbody2D rbody;
    private bool inpos = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rbody = this.GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        if (inpos) {
            Destroy(this.rbody);
            Destroy(this.GetComponent<BoxCollider2D>());
        }
    }

    public void inPos()
    {
        this.inpos = true;
    }
}
