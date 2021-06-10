using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BattleEffects : MonoBehaviour
{
    private TextMeshProUGUI damageT;
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
        if (damage == 0)
            damageT.text = "";
        else
            damageT.text = damage.ToString();
    }
}
