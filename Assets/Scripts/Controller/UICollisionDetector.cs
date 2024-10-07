using UnityEngine;
using System.Linq;
using System;

public class UICollisionDetector : MonoBehaviour
{

    public void CheckCollision(CardModel[,] sortedCards)
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
                        sortedCards[i, j].parentCard = closestElement.gameObject.GetComponent<CardModel>();
                        closestElement.GetComponent<CardModel>().childCard = sortedCards[i, j];
                    }
                }
            }
        }
    }


    RectTransform FindParentElement(RectTransform target, CardModel[] elements)
    {
        RectTransform closest = null;

        foreach (CardModel element in elements)
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

}
