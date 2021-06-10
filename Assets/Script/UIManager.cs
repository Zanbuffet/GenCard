using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{




    public GameObject cardDeck_player;
    
    
    public GameObject card_prefab;
    
    
    public List<GameObject> battleSlots;
    
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        for(int i = 0 ; i < battleSlots.Count;i++){
            battleSlots[i].GetComponent<Card_Field>().idx = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory.dirty_)
        {
            // delete all
            for( int i=0; i<cardDeck_player.transform.childCount; i++){
                Destroy(cardDeck_player.transform.GetChild(i).gameObject);
            }
            //add and refresh
            for(int i = 0; i<inventory.cards.Count;i++){
                GameObject tmp=Instantiate(card_prefab, cardDeck_player.transform);
                Card_Group cpmt = tmp.GetComponent<Card_Group>();
                cpmt.RefreshCard(inventory.cards[i]);
                cpmt.idx = i;
            }
           

            inventory.dirty_=false;
        }
        
    }

    public void Select_card(int idx)
    {
        inventory.cur_card=idx;
        Debug.Log("Select "+ idx);
    }

    public void Place_card(int slot_idx)
    {
        if(inventory.cur_card!=-1)
        {
            // add to field
            battleSlots[slot_idx].GetComponent<Card_Field>().RefreshCard(inventory.cards[inventory.cur_card]);

            // remove from inventory
            inventory.cards.RemoveAt(inventory.cur_card);
            inventory.cur_card=-1;
            if(GameObject.Find("TurnManager").GetComponent<TurnManager>().cur_turn==false){
                GameObject.Find("Turner_Player1").GetComponent<Turner1>().isChanged=true;
            }else if(GameObject.Find("TurnManager").GetComponent<TurnManager>().cur_turn==true){
                GameObject.Find("Turner_Player2").GetComponent<Turner2>().isChanged=true;
            }
            inventory.dirty_=true;
        }

        
    }

}
