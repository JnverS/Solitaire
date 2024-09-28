using UnityEngine;
using System.Linq;
using System;

public class UICollisionDetector : MonoBehaviour
{


    public void CheckCollision(Card[,] sortedCards)
    {
        int totalColumns = sortedCards.GetLength(1);
         for (int i = 0; i < sortedCards.GetLength(0); i++)
        {
            for (int j = 0; j < sortedCards.GetLength(1); j++)
            {
                var arr = Enumerable.Range(0, totalColumns)
                                 .Where(k => k != j)
                                 .Select(k => sortedCards[i, k])
                                 .ToArray();
                if (sortedCards[i, j] != null)
                {
                    RectTransform closestElement = FindParentElement(sortedCards[i, j].GetComponent<RectTransform>(), arr);

                    if (closestElement != null)
                    {
                        Debug.Log("Родитель для  " + sortedCards[i, j] + " - " + closestElement.name + "" + closestElement.GetSiblingIndex());
                        sortedCards[i, j].parentCard = closestElement.gameObject;
                        closestElement.GetComponent<Card>().childCard = sortedCards[i, j].gameObject;
                    }
                }
            }
        }
    }


    RectTransform FindParentElement(RectTransform target, Card[] elements)
    {
        RectTransform closest = null;

        foreach (Card element in elements)
        {
            if (element != null)
            {
                RectTransform el = element.GetComponent<RectTransform>();

                float distance = Mathf.Abs(el.position.z) - Mathf.Abs(target.position.z);

                if (Mathf.Approximately(.1f, (float)Math.Round(distance, 1)) || Mathf.Approximately(.09f, (float)Math.Round(distance, 2)))
                {
                    closest = el;
                    break;
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
