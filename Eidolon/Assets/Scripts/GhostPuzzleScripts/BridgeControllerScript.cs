using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeControllerScript : MonoBehaviour
{
    public BlockerScript blocker;
    public BlockerScript[] blockers;
    public BridgeScript[] bridgePieces;
    public GameObject[] activeBridgePieces;
    public Vector3[] bridgeVectors;
    private int amount;
    internal int count;
    // Start is called before the first frame update
    void Start()
    {
        amount = bridgePieces.Length;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(amount + "hey" + count);
        if(count == amount)
        {
            for(int i = 0; i < amount; i++)
            {
                Instantiate(activeBridgePieces[i],bridgeVectors[i],this.transform.rotation);
            }
            blocker.Destroy();
        }
    }
}
