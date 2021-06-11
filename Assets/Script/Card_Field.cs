using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Field : MonoBehaviour
{
    public delegate void CardDeath(int idx);
    public static CardDeath onCardDeath;
    public Card cardinfo;
    public int idx;
    private BattleEffects battleEffects;
    private ElementEffect elementEffect;
    private int currentHP;

    private void OnEnable()
    {
        onCardDeath += OnDeath;
    }
    private void Start()
    {
        battleEffects = GetComponent<BattleEffects>();
        elementEffect = GetComponent<ElementEffect>();
    }


    public void RefreshCard(Card cardinfo_)
    {
        cardinfo = cardinfo_;
        Debug.Log("Card Added! " + cardinfo.HP);
        currentHP = cardinfo.HP;
        transform.Find("HP").GetComponent<Text>().text = "" + currentHP;
        transform.Find("Attack").GetComponent<Text>().text = "" + cardinfo.Attack;
        transform.Find("Image").GetComponent<Image>().sprite = cardinfo.icon_field;


    }

    public void TakeDamage(Element elementType, int damage)
    {
        elementEffect.AddElement(elementType);
        currentHP -= damage;
        UpdateCard();
        //if (currentHP <= 0 && onCardDeath != null)
        //onCardDeath.Invoke();

        StartCoroutine(TakingDamage(damage));
    }



    IEnumerator TakingDamage(int damage)
    {
        GetComponent<Image>().color = Color.red;
        battleEffects.DisplayDamage(damage);
        yield return new WaitForSeconds(1f);
        battleEffects.DisplayDamage(0);
        GetComponent<Image>().color = Color.white;
        if (currentHP <= 0 && onCardDeath != null)
            onCardDeath(idx);
    }

    public void UpdateCard()
    {
        transform.Find("HP").GetComponent<Text>().text = "" + currentHP;
        //transform.Find("Image").GetComponent<Image>().sprite = cardinfo.icon_field;
    }
    public void OnSelect()
    {
        GameObject.Find("UIManager").GetComponent<UIManager>().Place_card(idx);
    }


    public void OnDeath(int idx)
    {
        if (this.idx == idx)
        {
            cardinfo = null;
            transform.Find("Image").GetComponent<Image>().sprite = null;
        }
    }

    private void OnDisable()
    {
        onCardDeath -= OnDeath;
    }
}
