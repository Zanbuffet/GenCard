using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Base : MonoBehaviour
{
    [SerializeField] private int baseHP = 40;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        healthText.text = baseHP.ToString();
    }
    public void BaseTakeDamage(int damage)
    {
        baseHP -= damage;
        healthText.text = baseHP.ToString();
    }
}
