using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupingCards : MonoBehaviour
{
    public GameObject[] _allCards;
    public CardModel[,] sortedCards;
    public int bunchCount = 4;
    public int cardsInBunchCount = 10;
    public RectMask2D[] groupMask;

    private void Awake()
    {
        _allCards = GameObject.FindGameObjectsWithTag("Card");
        sortedCards = new CardModel[bunchCount, cardsInBunchCount];
    }
    public void GroupBy()
    {

        for (int i = 0; i < groupMask.Length; i++)
        {
            int k = 0;
            for (int j = 0; j < _allCards.Length; j++)
            {
                if (IsInsideRectMask(_allCards[j].GetComponent<RectTransform>(), groupMask[i]))
                {
                    sortedCards[i, k] = _allCards[j].GetComponent<CardModel>();
                    k++;
                    if (k == 10)
                        break;
                }
            }

        }
    }

    bool IsInsideRectMask(RectTransform uiElement, RectMask2D mask)
    {

        Rect elementWorldRect = GetWorldRect(uiElement);


        Rect maskWorldRect = GetWorldRect(mask.GetComponent<RectTransform>());


        return maskWorldRect.Overlaps(elementWorldRect);
    }

    Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);

        Vector3 bottomLeft = corners[0];
        Vector3 topRight = corners[2];

        return new Rect(bottomLeft.x, bottomLeft.y, topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);
    }

}
