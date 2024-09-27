using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupingCards : MonoBehaviour
{
    public GameObject[] _allCards;
    /*    public List<List<Card>> _allBunches;
        public List<Card> firstBunch;
        public List<Card> secondBunch;
        public List<Card> thirdBunch;
        public List<Card> fourBunch;*/
    public Card[,] sortedCards;
    public int bunchCount = 5;
    public int cardsInBunchCount = 10;
    public RectMask2D[] groupMask;
    /*
    public SpriteMask spriteMask;    
    public RectMask2D groupMask2;
    public SpriteMask spriteMask2;*/
    private void Awake()
    {
        _allCards = GameObject.FindGameObjectsWithTag("Card");
        sortedCards = new Card[bunchCount, cardsInBunchCount];
    }
    public void GroupBy()
    {

        for (int i = 0; i < groupMask.Length; i++)
        {
            Debug.Log(groupMask[i]);
            int k = 0;
            for (int j = 0; j < _allCards.Length; j++)
            {
                if (IsInsideRectMask(_allCards[j].GetComponent<RectTransform>(), groupMask[i]))
                {
                    Debug.Log(_allCards[j]);
                    sortedCards[i, k] = _allCards[j].GetComponent<Card>();
                    k++;
                    if (k == 10)
                        break;
                }
            }

        }

        PrintTwiceArray();
    }

    private void PrintTwiceArray()
    {
        for (int i = 0; i < sortedCards.GetLength(0); i++)
        {
            string row = "";


            for (int j = 0; j < sortedCards.GetLength(1); j++)
            {
                row += sortedCards[i, j] + "\t";
            }

            Debug.Log(row);
        }
    }

    bool IsInsideRectMask(RectTransform uiElement, RectMask2D mask)
    {

        Rect elementWorldRect = GetWorldRect(uiElement);


        Rect maskWorldRect = GetWorldRect(mask.GetComponent<RectTransform>());


        return maskWorldRect.Overlaps(elementWorldRect);
    }

    bool IsInsideRectMask(RectTransform uiElement, SpriteMask mask)
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
