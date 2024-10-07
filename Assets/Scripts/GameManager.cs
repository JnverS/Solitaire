using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UICollisionDetector detector;
    public GroupingCards gp;
    public GeneratingCombinations generator;

    private void Start()
    {
        gp.GroupBy();
        detector.CheckCollision(gp.sortedCards);

        generator.StartGeneration(gp._allCards.Length, gp.sortedCards);
        foreach (var item in gp.sortedCards)
        {
            if (item.isOpen == true)
                item.Set();
        }
        Bank.instance.OpeningBankCard();
    }
}
