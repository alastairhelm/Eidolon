using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private Animator anim;
    string state = "down";
    Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        prevPos = this.transform.position;
        this.anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (prevPos.x < this.transform.position.x) {
            this.anim.SetBool(state, false);
            this.anim.SetBool("right", true);
            this.state = "right";
        } else if (prevPos.x > this.transform.position.x ) {
            this.anim.SetBool(state, false);
            this.anim.SetBool("left", true);
            this.state = "left";
        } else if (prevPos.y < this.transform.position.y) {
            this.anim.SetBool(state, false);
            this.anim.SetBool("down", true);
            this.state = "down";
        } else if (prevPos.y > this.transform.position.y ) {
            this.anim.SetBool(state, false);
            this.anim.SetBool("up", true);
            this.state = "up";
        }
        prevPos = this.transform.position;
    }
}
