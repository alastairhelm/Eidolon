using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPull : MonoBehaviour
{
    public float dist = 0.5f;

    private GameObject block;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        //Physics2D.queriesStartInColliders = false;
        Character player = this.GetComponent<Character>();
        RaycastHit2D hit;
        if (player.lastReleased == "D") {
            hit = Physics2D.Raycast(this.transform.position, Vector2.right, dist * transform.localScale.x, LayerMask.GetMask("Blocks"));
        } else if (player.lastReleased == "A") {
            hit = Physics2D.Raycast(this.transform.position, Vector2.left, dist * transform.localScale.x, LayerMask.GetMask("Blocks"));
        } else if (player.lastReleased == "W") {
            hit = Physics2D.Raycast(this.transform.position, Vector2.up, dist * transform.localScale.y, LayerMask.GetMask("Blocks"));
        } else {
            hit = Physics2D.Raycast(this.transform.position, Vector2.down, dist * transform.localScale.y, LayerMask.GetMask("Blocks"));
        }


        if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKeyDown(KeyCode.E))
        {            
            block = hit.collider.gameObject;
            block.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            block.GetComponent<FixedJoint2D>().enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.E) && block != null)
        {
            block.GetComponent<FixedJoint2D>().enabled = false;
            block.GetComponent<FixedJoint2D>().connectedBody = null;
            block.GetComponent<PushPuzzlePiece>().rbody.velocity = Vector2.zero;
        }

    }

    public void OnDrawGizmos() {

        Gizmos.color = Color.yellow;
        Character player = this.GetComponent<Character>();
        if(player.lastReleased == "A" || player.lastReleased == "D")
        {
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * dist);
        } else {
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.up* transform.localScale.y * dist);
        }
    }
}
