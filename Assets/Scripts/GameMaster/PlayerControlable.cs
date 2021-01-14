using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlable : MonoBehaviour 
{

    public void playerControl(bool var)
    {
        isSelected = var;
    }
    protected bool isSelected;
}
