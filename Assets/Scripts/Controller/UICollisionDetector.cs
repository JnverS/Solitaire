using UnityEngine;
using System.Linq;
using System;

public class UICollisionDetector : MonoBehaviour
{


   public void CheckCollision(Card[,] sortedCards)
    {
        //for (int i = 0; i < sortedCards.GetLength(0); i++)
        {
            for (int j = 0; j < sortedCards.GetLength(1); j++)
            {
                int totalColumns = sortedCards.GetLength(1) - 1;
 
                var arr =  Enumerable.Range(0, totalColumns)
                                 .Where(k=>k!=j)
                                 .Select(k => sortedCards[0, k])
                                 .ToArray();
                
                RectTransform closestElement = FindParentElement(sortedCards[0,j].GetComponent<RectTransform>(), arr);
                if (closestElement != null)
                {
                    Debug.Log("Родитель для  "+ sortedCards[0,j] + " - " + closestElement.name + "" + closestElement.GetSiblingIndex());
                }
            }

        }
    }


    RectTransform FindParentElement(RectTransform target, Card[] elements)
    {
        RectTransform closest = null;
        float closestDistance = Mathf.Infinity;
        int sIndexTarget = target.GetSiblingIndex();
        int sIndexParent = elements[elements.Length-1].GetComponent<RectTransform>().GetSiblingIndex() ; 

        foreach (Card element in elements)
        {
            RectTransform el = element.GetComponent<RectTransform>();
           // Debug.Log(el.name);
            float distance = Vector2.Distance(target.position, el.position);
            int siblingIndex = el.GetSiblingIndex();

            if (distance <= closestDistance && siblingIndex > sIndexTarget)
            {
                if (siblingIndex <= sIndexParent)
                {
                    sIndexParent = siblingIndex;
                    closestDistance = distance;
                    closest = el;
                }
            }
        }

        return closest;
    }
    /*RectTransform FindClosestElement(RectTransform target, Card[] elements)
    {
        RectTransform closest = null;
        float closestDistance = Mathf.Infinity;
        int child = 0;

        foreach (Card element in elements)
        {
            RectTransform el = element.GetComponent<RectTransform>();

            float distance = Vector2.Distance(target.position, el.position);

        
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = el;
            }
        }

        return closest;
    }
*/

}
