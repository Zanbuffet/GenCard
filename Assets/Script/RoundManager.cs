using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public bool cur_turn= true;// true stands for player1; false stands for player2
    
    public void TakeTurn(){
        cur_turn=!cur_turn;
    }
}
