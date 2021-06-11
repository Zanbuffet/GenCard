using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : Card
{
    //init
    public int cur_HP_=0;
    public void InitFromCard(Card card_info){
        cur_HP=card_info.HP;
        this.HP=cur_HP;
    }
    //calculate

}
