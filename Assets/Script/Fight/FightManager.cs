using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FightManager : MonoBehaviour
{
    //public List<Card> fightQueue = new List<Card>();
    public Dictionary<int, Card> fightQueue = new Dictionary<int, Card>();
    public List<GameObject> slots = new List<GameObject>();     //temp
    public GameObject enemyBase;
    public void InitFighting()
    {
        foreach (var slot in slots)
        {
            Card card = slot.GetComponent<Card_Field>().cardinfo;
            if (card != null)
            {
                //slot.GetComponent<Card_Field>().RefreshCard(card);
                fightQueue.Add(slot.GetComponent<Card_Field>().idx, card);
            }
        }
    }

    IEnumerator Fighting()
    {
        foreach (var card in fightQueue)
        {
            //temp effect
            slots[card.Key].GetComponent<Image>().color = Color.green;
            GameObject[] targets = GetTargets(card.Key).ToArray();
            foreach (var tar in targets)
            {
                Debug.Log("Card " + card + "Attack " + tar.name + "  Damage: " + card.Value.HP);
                Card_Field targetCard = tar.GetComponent<Card_Field>();
                if (targetCard != null)
                {
                    targetCard.TakeDamage(card.Value.Attack);
                }

            }
            //CardFight(fightQueue[i]);
            yield return new WaitForSeconds(2f);
            slots[card.Key].GetComponent<Image>().color = Color.white;
        }
    }


    private List<GameObject> GetTargets(int idx)
    {
        List<GameObject> targets = new List<GameObject>();
        if (idx > 0 && idx < slots.Count - 1)
        {
            if (fightQueue.ContainsKey(idx + 1))
            {
                //Card card = fightQueue[idx + 1];
                targets.Add(slots[idx + 1]);
            }
            if (fightQueue.ContainsKey(idx - 1))
            {
                //Card card = fightQueue[idx + 1];
                targets.Add(slots[idx - 1]);
            }
            if (targets.Count < 2)
            {
                targets.Add(enemyBase);
            }
        }
        return targets;

    }
    public void InitButton()
    {
        //
        InitFighting();
        //
    }
    public void FightButton()
    {
        InitFighting();
        Debug.Log("FightInit!");
        StartCoroutine(Fighting());
        GameObject.Find("TurnManager").GetComponent<TurnManager>().InitTurn();
    }
}
