using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "GenCard/Card", order = 0)]
public class Card : ScriptableObject
{
    public new string name = "";
    public int HP = 36;
    public int cur_HP = 0;
    public int Attack = 0;
    public int cost = 0;

    public Element element = Element.none;
    public Sprite icon_field = null;
    public Sprite icon_deck = null;
}

    public enum Element
    {
        fire,
        water,
        ice,
        none
    }