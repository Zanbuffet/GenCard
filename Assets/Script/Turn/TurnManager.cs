using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnManager : MonoBehaviour
{
    private Turner1 turner1;
    private Turner2 turner2;
    public Sprite On;
    public Sprite Off;
    public GameObject cover1;
    public GameObject cover2;
    public bool fillCard = false;
    public bool nextPhase = false;
    public bool cur_turn = false;//false stands for P1.
    public bool round2 = false;
    void Start()
    {
        //    GameObject cover1_=Instantiate(cover1, GameObject.Find("Canvas").transform);
        Instantiate(cover2, GameObject.Find("Canvas").transform);
    }
    public void InitTurn()
    {
        Destroy(GameObject.Find("Cover1(Clone)"));
        Destroy(GameObject.Find("Cover2(Clone)"));
        Instantiate(cover2, GameObject.Find("Canvas").transform);
        GameObject.Find("Turner_Player1").GetComponent<Turner1>().statement = true;
        GameObject.Find("Turner_Player2").GetComponent<Turner2>().isChanged = true;
        GameObject.Find("Turner_Player1").GetComponent<Image>().sprite = On;
        fillCard = true;
        cur_turn = false;
        round2 = true;

        GameObject.Find("P1Base").GetComponent<PlayerBase>().BaseRecoverCost();
        GameObject.Find("P2Base").GetComponent<PlayerBase>().BaseRecoverCost();

    }
    public void Switch_Turn_to_P2(bool statement)
    {
        if (GameObject.Find("Turner_Player2").GetComponent<Turner2>().isChanged == true)
        {
            GameObject.Find("Turner_Player2").GetComponent<Turner2>().statement = true;
            GameObject.Find("Turner_Player2").GetComponent<Image>().sprite = On;
            Instantiate(cover1, GameObject.Find("Canvas").transform);
            Destroy(GameObject.Find("Cover2(Clone)"));
            Debug.Log("Now the P2 turn");
            GameObject.Find("Turner_Player2").GetComponent<Turner2>().isChanged = false;
            cur_turn = true;
            return;
        }
        Debug.Log("Fight!");
        GameObject.Find("Turner_Player2").GetComponent<Image>().sprite = Off;
        Instantiate(cover1, GameObject.Find("Canvas").transform);
        GameObject.Find("FightManager").GetComponent<FightManager>().FightButton();
        // GameObject.Find("Turner_Player2").GetComponent<Turner2>().skip=true;
        // GameObject.Find("Turner_Player1").GetComponent<Turner1>().statement=true;
        // GameObject.Find("Turner_Player1").GetComponent<Image>().sprite=On;
        // GameObject.Find("Turner_Player1").GetComponent<Turner1>().isChanged=false;

    }
    public void Switch_Turn_to_P1(bool statement)
    {
        if (GameObject.Find("Turner_Player1").GetComponent<Turner1>().isChanged == true)
        {
            GameObject.Find("Turner_Player1").GetComponent<Turner1>().statement = true;
            GameObject.Find("Turner_Player1").GetComponent<Image>().sprite = On;
            Instantiate(cover2, GameObject.Find("Canvas").transform);
            Destroy(GameObject.Find("Cover1(Clone)"));
            Debug.Log("Now the P1 turn");
            GameObject.Find("Turner_Player1").GetComponent<Turner1>().isChanged = false;
            cur_turn = false;
            return;
        }
        Debug.Log("Fight!");
        GameObject.Find("Turner_Player1").GetComponent<Image>().sprite = Off;
        Instantiate(cover2, GameObject.Find("Canvas").transform);
        GameObject.Find("FightManager").GetComponent<FightManager>().FightButton();
        // GameObject.Find("Turner_Player1").GetComponent<Turner1>().skip=true;
        // GameObject.Find("Turner_Player2").GetComponent<Turner2>().statement=true;
        // GameObject.Find("Turner_Player2").GetComponent<Image>().sprite=On;
        // GameObject.Find("Turner_Player2").GetComponent<Turner2>().isChanged=false;
    }
}
