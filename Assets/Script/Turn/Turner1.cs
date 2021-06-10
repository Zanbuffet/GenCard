using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turner1 : MonoBehaviour
{
    public Sprite On;
    public Sprite Off;
    public bool statement;
    public bool isChanged;
    public bool skip;
    public void onclick(){
        statement = !statement;
        if(statement==true){
            transform.GetComponent<Image>().sprite = On;
        }else{
            transform.GetComponent<Image>().sprite = Off;
            GameObject.Find("TurnManager").GetComponent<TurnManager>().Switch_Turn_to_P2(statement);
        }
    }
    
}
