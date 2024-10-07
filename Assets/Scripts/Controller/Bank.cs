using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bank : MonoBehaviour, IPointerClickHandler
{
    public static Bank instance;
    public List<Rank> bankCards;
    public CardModel openBankCard;
    int currentBankCard;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    
    
    public void AddToBank(Rank card)
    {
        bankCards.Add(card);
        currentBankCard = bankCards.Count - 1;
    }
    public void OpeningBankCard()
    {
        openBankCard.rank = bankCards[currentBankCard];
        currentBankCard--;
        openBankCard.Set();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentBankCard >= 0)
        {
            OpeningBankCard();

            if (currentBankCard == -1)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public bool CheckCombination(Rank rat)
    {
        if (RatingCheck.NextState(rat, 1) == openBankCard.rank || RatingCheck.NextState(rat, -1) == openBankCard.rank)
        {
            openBankCard.rank = rat;
            openBankCard.Set();
            return true;
        }
        return false;
    }
}
