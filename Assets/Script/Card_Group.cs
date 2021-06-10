using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Group : MonoBehaviour
{
    public Card cardinfo;
    public int idx;


    public void RefreshCard(Card cardinfo_) {
        cardinfo=cardinfo_;
        transform.Find("Container").Find("HP").GetComponent<Text>().text=""+cardinfo.HP;
        transform.Find("Container").Find("cost").GetComponent<Text>().text=""+cardinfo.cost;
        transform.Find("Container").Find("Image").GetComponent<Image>().sprite=cardinfo.icon_deck;
    }

    public void OnSelect(){
        // call ui
        GameObject.Find("UIManager").GetComponent<UIManager>().Select_card(idx);
    }
    private bool isHover = false;

    public void MouseOn(){
        isHover = true;
    }
    public void MouseExit(){
        isHover = false;
    }
    private Transform containerTransform;
    private HorizontalLayoutGroup deckTransform;
    private float originalSpacing;
    public float horizontalDistance;
    private Vector3 originalPos;
    public  Vector3 distance;
    public float moveSpeed;
    private TurnManager turnManager;
    private void Start() {
        containerTransform = transform.Find("Container").GetComponent<RectTransform>();
        originalPos = containerTransform.localPosition;
        deckTransform = transform.parent.GetComponent<HorizontalLayoutGroup>();
        originalSpacing = deckTransform.spacing;
        turnManager=GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }
    public void Update(){
        if(isHover){
            containerTransform.localPosition = Vector3.Lerp(containerTransform.localPosition, originalPos+distance, moveSpeed * Time.deltaTime);
            deckTransform.spacing = Mathf.Lerp(deckTransform.spacing, originalSpacing+ horizontalDistance,moveSpeed*Time.deltaTime );
        }else{
            containerTransform.localPosition = Vector3.Lerp(containerTransform.localPosition, originalPos, moveSpeed * Time.deltaTime);
            deckTransform.spacing = Mathf.Lerp(deckTransform.spacing, originalSpacing,moveSpeed*Time.deltaTime );
        }
    }
    
}
