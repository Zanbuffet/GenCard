using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FightManager : MonoBehaviour
{
    //public List<Card> fightQueue = new List<Card>();
    public Dictionary<int, Card> fightQueue = new Dictionary<int, Card>();
    public List<GameObject> slots = new List<GameObject>();     //temp
    public GameObject P1Base;
    public GameObject P2Base;
    private void OnEnable()
    {
        Card_Field.onCardDeath += RemoveFromQueue;
    }
    public void InitFighting()
    {   
        fightQueue.Clear();
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
        Debug.Log("WhynotFight!");
        foreach (var slot in slots)
        {
            Card card = slot.GetComponent<Card_Field>().cardinfo;
            if (card != null)
            {
                slot.GetComponent<Image>().color = Color.green;
                GameObject[] targets = GetTargets(slot.GetComponent<Card_Field>().idx).ToArray();
                foreach (var tar in targets)
                {
                    Debug.Log("Card " + card + "Attack " + tar.name + "  Damage: " + card.Attack);
                    Card_Field targetCard = tar.GetComponent<Card_Field>();
                    if (targetCard != null)
                    {
                        targetCard.TakeDamage(card.element,card.Attack);
                    }
                    else
                        BaseAttack(tar, card.Attack);
                }
                yield return new WaitForSeconds(2f);
                slot.GetComponent<Image>().color = Color.white;
            }
        }
    }

    private void BaseAttack(GameObject tar, int damage)
    {
        tar.GetComponent<Base>().BaseTakeDamage(damage);
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
                if (idx % 2 == 0)
                {
                    targets.Add(P2Base);
                }
                else
                    targets.Add(P1Base);
            }
        }
        else if (idx == 0)
        {
            if (fightQueue.ContainsKey(idx + 1))
            {
                //Card card = fightQueue[idx + 1];
                targets.Add(slots[idx + 1]);
            }
        }
        else
        {
            if (fightQueue.ContainsKey(idx - 1))
            {
                //Card card = fightQueue[idx + 1];
                targets.Add(slots[idx-1]);
            }
        }
        return targets;

    }

    public void RemoveFromQueue(int idx)
    {
        Debug.Log("REMOVE IT");
        fightQueue.Remove(idx);
    }
    public void InitButton()
    {
        //
        InitFighting();
        //
    }
    public void FightButton()
    {
        StartCoroutine(StillFighting());
    }
    IEnumerator StillFighting()
    {
        InitFighting();
        yield return StartCoroutine(Fighting());
        Debug.Log("FightEnds");
        foreach(var slot in slots)
        {
            slot.GetComponent<BattleEffects>().ResetElements(slot.GetComponent<Card_Field>().idx);
        }
        GameObject.Find("TurnManager").GetComponent<TurnManager>().InitTurn();
    }
}
