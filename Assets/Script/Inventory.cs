using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    /*
    #region Singleton Pattern
    public static Inventory instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //keep gameobjects when changing scenes
        }
        else
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            Destroy(gameObject);
            //if exist a gameObject, then destory current gameObject
        }
    }
    #endregion
    */

    public List<Card> cards = new List<Card>();
    [SerializeField] public List<Card> Example_cards = new List<Card>();
    public int cur_card = -1;
    public GameObject Prefab_Button;
    public bool dirty_=false;
    private void Start() {
        cards=Example_cards;
    }
    public void Select_card()
    {

    }





}
