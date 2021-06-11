using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
public class BattleEffects : MonoBehaviour
{
    private TextMeshProUGUI damageT;
    public List<Element> currentElements = new List<Element>();
    public GameObject[] buffSlots;
    public Sprite[] elementSprites;
    public ElementEffectType[] elementEffects;
    private void OnEnable()
    {
        Card_Field.onCardDeath += ResetElements;
    }
    private void Start()
    {
        damageT = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void Attack()
    {
        //scaleup anim
    }

    public void DisplayDamage(int damage)
    {
        string effectDescription = "";
        if (damage == 0)
        {
            damageT.text = "";
            if (currentElements.Count > 1)
            {
                currentElements.Clear();
                foreach (var buff in buffSlots)
                {
                    buff.GetComponent<Image>().color = Color.clear;
                }
            }
            return;
        }

        foreach (var combo in elementEffects)
        {
            if (combo.elementCombo.SequenceEqual(currentElements))
            {
                effectDescription = combo.description;
                damageT.color = combo.descriptionColor;
            }
        }
        damageT.text = effectDescription + '\n' + damage.ToString();
    }


    public int ElementDamage(int damage)
    {
        float elementDamage = damage;
        foreach (var combo in elementEffects)
        {
            if (combo.elementCombo.SequenceEqual(currentElements))
            {
                elementDamage = elementDamage * combo.damage;
            }
        }
        return (int)elementDamage;
    }

    public void ResetElements(int idx)
    {
        if (GetComponent<Card_Field>().idx == idx)
        {
            currentElements.Clear();
            foreach (var buff in buffSlots)
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
