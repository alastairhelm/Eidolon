using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class CamerController : MonoBehaviour
{
    public PlayerControlable player;
    public PlayerController playerController;
    public Carrot carrot;
    Camera camera;
    


   // Start is called before the first frame update
   void Start()
    {
        camera = GetComponent<Camera>();
        
    }


    // Update is called once per frame
    void Update()
    {
        player = playerController.getCurrenlySelected();
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);

    }

}
