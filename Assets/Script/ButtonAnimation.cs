using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public void Onclick()
    {
        transform.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(10,30);
        Debug.Log("Move");
//        rt.sizeDelta = new Vector2(10,30);
    }
}
