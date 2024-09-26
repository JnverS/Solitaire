using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupingCards : MonoBehaviour
{
    public List<Card> _allCards;
    public List<Card> firstBunch;
    public List<Card> secondBunch;
    public List<Card> thirdBunch;
    public List<Card> fourBunch;
    public RectMask2D groupMask;
    public SpriteMask spriteMask;    
    public RectMask2D groupMask2;
    public SpriteMask spriteMask2;
    private void Start()
    {
        foreach (var item in _allCards)
        {
            if (IsInsideRectMask(item.GetComponent<RectTransform>(), spriteMask))
            {
                firstBunch.Add(item);
            }
            else if (IsInsideRectMask(item.GetComponent<RectTransform>(), groupMask))
            {
                secondBunch.Add(item);
            }            
            else if (IsInsideRectMask(item.GetComponent<RectTransform>(), spriteMask2))
            {
                thirdBunch.Add(item);
            }
            else if (IsInsideRectMask(item.GetComponent<RectTransform>(), groupMask2))
            {
                fourBunch.Add(item);
            }
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
