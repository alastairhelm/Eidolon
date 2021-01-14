using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polePuzzleControl : MonoBehaviour
{
    public List<poleBehavior> totems;
    public List<bool> activatedTotems;
    public GameObject exit;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<=3; i++) {
            activatedTotems[i] = false;
        }
    }

    // Update is called once per frame
    public void totemCheck()
    {

        for (int i = 0; i <= 3; i++)
        {


            activatedTotems[i] = totems[i].getState();
            //if (i != 0) {
            //    if (!(checkState(i))) {
            //        for (int j = 0; j <= 3; j++)
            //        {
            //            activatedTotems[j] = false;
            //            totems[j].activated = false;
                       
            //        }
            //        this.GetComponent<DialogueTrigger>().TriggerDialogue();
            //    }
            //}
        }
    }

    bool checkState(int curr) {
        bool correct = true;
        for (int i = 0; i < curr; i++)
        {
            if (activatedTotems[i] == false) { correct = false;
                return correct;
            }
        }
        return correct;
    }

   
}
