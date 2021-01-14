using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPuzzlePiece : MonoBehaviour
{

    public Rigidbody2D rbody;
   

    [SerializeField]
    private bool h;

    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        this.rbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionExit2D(Collision2D collision)  {
        rbody.velocity = Vector2.zero;
    }
}
