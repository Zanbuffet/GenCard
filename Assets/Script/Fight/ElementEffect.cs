using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElementEffect : MonoBehaviour
{
    public List<Element> currentElements = new List<Element>();
    public GameObject[] buffSlots;
    public Sprite[] elementSprites;
    private void OnEnable()
    {
        Card_Field.onCardDeath += ResetElements;
    }
    public void TakeElementDamage(Element element, int damage)
    {

    }

    public void ResetElements(int idx)
    {
        if(GetComponent<Card_Field>().idx == idx)
        {
            currentElements.Clear();
            foreach(var buff in buffSlots)
            {
                buff.GetComponent<Image>().color = Color.clear;
            }
        }
    }

    public void AddElement(Element elementType)
    {
        if (!currentElements.Contains(elementType))
        {
            if (elementType != Element.none)
            {
                currentElements.Add(elementType);
                if (currentElements.Count == 1)
                {
                    buffSlots[0].GetComponent<Image>().sprite = elementSprites[((int)elementType)];
                    buffSlots[0].GetComponent<Image>().color = Color.white;
                }
                else
                {
                    buffSlots[1].GetComponent<Image>().sprite = elementSprites[((int)elementType)];
                    buffSlots[1].GetComponent<Image>().color = Color.white;
                }
            }
        }
    }

}
