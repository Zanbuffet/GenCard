using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject cardDeck_player_1;
    public GameObject cardDeck_player_2;
    public GameObject card_prefab;
    public GameObject card_fill;
    public List<GameObject> battleSlots;
    public GameObject inventory_1;
    public GameObject inventory_2;
    Inventory tmp_inventory_1;
    Inventory tmp_inventory_2;

    // Start is called before the first frame update
    void Start()
    {
        //inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        tmp_inventory_1 = inventory_1.GetComponent<Inventory>();
        tmp_inventory_2 = inventory_2.GetComponent<Inventory>();
        for(int i = 0 ; i < battleSlots.Count;i++){
            battleSlots[i].GetComponent<Card_Field>().idx = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tmp_inventory_1.dirty_)
        {
            //delete all
            for( int i=0; i<cardDeck_player_1.transform.childCount; i++){
                Destroy(cardDeck_player_1.transform.GetChild(i).gameObject);
            }
            //add and refresh
            if(GameObject.Find("TurnManager").GetComponent<TurnManager>().round2==false)
            {
            for(int i = 0; i<tmp_inventory_1.cards.Count-1;i++){
                GameObject tmp=Instantiate(card_prefab, cardDeck_player_1.transform);
                Card_Group cpmt = tmp.GetComponent<Card_Group>();
                cpmt.RefreshCard(tmp_inventory_1.cards[i]);
                cpmt.idx = i;
                }
            }else{
            for(int i = 0; i<tmp_inventory_1.cards.Count;i++){
                GameObject tmp=Instantiate(card_prefab, cardDeck_player_1.transform);
                Card_Group cpmt = tmp.GetComponent<Card_Group>();
                cpmt.RefreshCard(tmp_inventory_1.cards[i]);
                cpmt.idx = i;
            }
            }
            }
            tmp_inventory_1.dirty_=false;
        

        if(tmp_inventory_2.dirty_)
        {
            // delete all
            for( int i=0; i<cardDeck_player_2.transform.childCount; i++){
                Destroy(cardDeck_player_2.transform.GetChild(i).gameObject);
            }
            //add and refresh
            if(GameObject.Find("TurnManager").GetComponent<TurnManager>().round2==false)
            {
            for(int i = 0; i<tmp_inventory_2.cards.Count-1;i++){
                GameObject tmp=Instantiate(card_prefab, cardDeck_player_2.transform);
                Card_Group cpmt = tmp.GetComponent<Card_Group>();
                cpmt.RefreshCard(tmp_inventory_2.cards[i]);
                cpmt.idx = i;
            }
            }else{
                for(int i = 0; i<tmp_inventory_2.cards.Count;i++){
                GameObject tmp=Instantiate(card_prefab, cardDeck_player_2.transform);
                Card_Group cpmt = tmp.GetComponent<Card_Group>();
                cpmt.RefreshCard(tmp_inventory_2.cards[i]);
                cpmt.idx = i;
            }
            }
            tmp_inventory_2.dirty_=false;
        }
        if(GameObject.Find("TurnManager").GetComponent<TurnManager>().fillCard==true)
            {
                GameObject tmp_fill=Instantiate(card_fill, cardDeck_player_1.transform);
                Card_Group cpmt_fill = tmp_fill.GetComponent<Card_Group>();
                cpmt_fill.RefreshCard(tmp_inventory_1.cards[tmp_inventory_1.cards.Count-1]);
                cpmt_fill.idx = tmp_inventory_1.cards.Count-1;
                tmp_fill=Instantiate(card_fill, cardDeck_player_2.transform);
                cpmt_fill = tmp_fill.GetComponent<Card_Group>();
                cpmt_fill.RefreshCard(tmp_inventory_2.cards[tmp_inventory_2.cards.Count-1]);
                cpmt_fill.idx = tmp_inventory_2.cards.Count-1;
                GameObject.Find("TurnManager").GetComponent<TurnManager>().fillCard=false;
            }

        
    }

    public void Select_card(int idx)
    {
         if(GameObject.Find("TurnManager").GetComponent<TurnManager>().cur_turn==false)
         {
         tmp_inventory_1.cur_card=idx;
         Debug.Log("Select "+ idx);
         }
         if(GameObject.Find("TurnManager").GetComponent<TurnManager>().cur_turn==true)
         {
         tmp_inventory_2.cur_card=idx;
         Debug.Log("Select "+ idx);
         }
    }

    public void Place_card(int slot_idx)
    {
        if(tmp_inventory_1.cur_card!=-1)
        {
            // add to field
            Debug.Log("Success1!");
            battleSlots[slot_idx].GetComponent<Card_Field>().RefreshCard(tmp_inventory_1.cards[tmp_inventory_1.cur_card]);
            Debug.Log("Success2!");
            // remove from inventory_1
            tmp_inventory_1.cards.RemoveAt(tmp_inventory_1.cur_card);
            Debug.Log("cur_card: "+tmp_inventory_1.cur_card);
            tmp_inventory_1.cur_card=-1;
            if(GameObject.Find("TurnManager").GetComponent<TurnManager>().cur_turn==false){
                GameObject.Find("Turner_Player1").GetComponent<Turner1>().isChanged=true;
            }else if(GameObject.Find("TurnManager").GetComponent<TurnManager>().cur_turn==true){
                GameObject.Find("Turner_Player2").GetComponent<Turner2>().isChanged=true;
            }
            tmp_inventory_1.dirty_=true;
        }
        if(tmp_inventory_2.cur_card!=-1)
        {
            // add to field
            battleSlots[slot_idx].GetComponent<Card_Field>().RefreshCard(tmp_inventory_2.cards[tmp_inventory_2.cur_card]);

            // remove from tmp_inventory_2
            tmp_inventory_2.cards.RemoveAt(tmp_inventory_2.cur_card);
            tmp_inventory_2.cur_card=-1;
            if(GameObject.Find("TurnManager").GetComponent<TurnManager>().cur_turn==false){
                GameObject.Find("Turner_Player1").GetComponent<Turner1>().isChanged=true;
            }else if(GameObject.Find("TurnManager").GetComponent<TurnManager>().cur_turn==true){
                GameObject.Find("Turner_Player2").GetComponent<Turner2>().isChanged=true;
            }
            tmp_inventory_2.dirty_=true;
        }

        
    }

}
