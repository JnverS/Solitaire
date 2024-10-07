using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardModel : MonoBehaviour, IPointerClickHandler
{
    public CardModel childCard;
    public CardModel parentCard;
    public Image pic;
    public Rank rank;
    public bool isOpen;

    public void Set()
    {
        pic = GetComponent<Image>();
        if (isOpen)
            pic.sprite = Resources.Load<Sprite>("Cards/Black" + rank);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isOpen)
            return;
        if (Bank.instance.CheckCombination(rank))
        {
            if (childCard != null)
            {
                childCard.isOpen = true;
                childCard.Set();
            }
            Destroy(this.gameObject);
        }
    }
}
