using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
   
    public GameObject Panel;
    public IEnumerator show() {
        yield return new WaitForSeconds(3);
        Panel.gameObject.SetActive(false);
    }

    public void displayItem(Item item, int x, int y) {
        Item.Instantiate(item, item.transform);

        Sprite i = Image.Instantiate(item.GetComponent<SpriteRenderer>().sprite, this.transform);
        
    }

    public void UpdateText(string text)
    {
        GameObject textItem = Panel.transform.GetChild(0).gameObject;
        textItem.GetComponent<Text>().text = text;

    }

    private void Start()
    {
        //Panel.SetActive(false);
    }
}
