using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Card[] cards;
    public UICollisionDetector detector;

    private void Start()
    {
        for (int i = 1; i < cards.Length; i++)
        {
            if (detector.IsOverlapping(cards[i].GetComponent<RectTransform>(), cards[i - 1].GetComponent<RectTransform>()))
            {
                Debug.Log("UI элементы пересекаются!");
            }
        }
    }
}
