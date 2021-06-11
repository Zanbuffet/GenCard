using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "GenCard/ElementEffect", order = 0)]
public class ElementEffectType : ScriptableObject
{
    public new string name;
    public List<Element> elementCombo = new List<Element>();
    public float damage;
    public string description;
    public Color descriptionColor;
}
