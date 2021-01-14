using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    internal bool isActive;
    public BridgeControllerScript control;
    void Start()
    {
        isActive = false;   
    }
    internal void activateSwitch()
    {
        isActive = !isActive;
        if (isActive)
        {
            control.count++;
        }
        else
        {
            control.count--;
        }
    }

}
