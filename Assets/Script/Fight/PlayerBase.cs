using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerBase : MonoBehaviour
{
    [SerializeField] private int baseHP = 40;
    [SerializeField] public int baseCost = 8;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI costText;

    private void Start()
    {
        healthText.text = baseHP.ToString();
        costText.text = baseCost.ToString();
    }
    public void BaseTakeDamage(int damage)
    {
        baseHP -= damage;
        healthText.text = baseHP.ToString();
    }
    public void BaseReduceCost(int cost)
    {
        baseCost -= cost;
        costText.text = baseCost.ToString();
    }
}
