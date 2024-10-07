using UnityEngine;

public class GeneratingCombinations : MonoBehaviour
{
    int[,] inBunchIndex;
    public void StartGeneration(int allCardsCount, CardModel[,] sortedCards)
    {
        Rank[] newCombination;
        int countcardincomb = 0;
        inBunchIndex = GetIndexes(sortedCards);
        while (allCardsCount > 0)
        {
            int combinationCount = 0;
            if (allCardsCount >= 7)
                combinationCount = Random.Range(2, 8);
            else
                combinationCount = allCardsCount + 1;

            newCombination = CreateCombination(combinationCount);
            allCardsCount -= combinationCount - 1;
            countcardincomb += combinationCount;

            Bank.instance.AddToBank(newCombination[0]);

            for (int i = newCombination.Length - 1; i > 0; i--)
            {
                bool cardPlaced = false;

                while (!cardPlaced)
                {
                    int randomBunch = Random.Range(0, 4);

                    if (inBunchIndex[randomBunch, 0] < sortedCards.GetLength(1))
                    {
                        SetRating(sortedCards, newCombination[i], randomBunch);
                        cardPlaced = true;

                    }
                }
            }
        }
    }

    private void SetRating(CardModel[,] sortedCards, Rank newCombination, int randomBunch)
    {
        sortedCards[randomBunch, inBunchIndex[randomBunch, 0]].rank = newCombination;

        sortedCards[randomBunch, inBunchIndex[randomBunch, 0]].Set();

        CardModel target = sortedCards[randomBunch, inBunchIndex[randomBunch, 0]].parentCard;
        if (target == null)
        {
            inBunchIndex[randomBunch, 0] = sortedCards.GetLength(1);
            return;
        }
        else
        {
            for (int j = 0; j < sortedCards.GetLength(1); j++)
            {
                if (sortedCards[randomBunch, j] == target)
                {
                    inBunchIndex[randomBunch, 0] = j;
                    return;
                }
            }
        }
    }

    private int[,] GetIndexes(CardModel[,] sortedCards)
    {
        int[,] inBunchIndex = new int[sortedCards.GetLength(0), 1];
        for (int j = 0; j < sortedCards.GetLength(0); j++)
        {
            for (int i = 0; i < sortedCards.GetLength(1); i++)
            {
                if (sortedCards[j, i] != null)
                {
                    if (sortedCards[j, i].childCard == null)
                    {

                        inBunchIndex[j, 0] = i;
                        break;
                    }
                }
            }
        }

        return inBunchIndex;
    }

    private Rank[] CreateCombination(int combinationCount)
    {
        Rank[] newCombination = new Rank[combinationCount];
        int revertIndex = -1;

        int combinationType = Random.Range(0, 100);
        int start = Random.Range(0, System.Enum.GetNames(typeof(Rank)).Length);
        newCombination[0] = (Rank)System.Enum.ToObject(typeof(Rank), start);

        int direction = 1;

        bool revert = Random.Range(0, 100) > 85 ? true : false;

        if (revert)
        {
            revertIndex = Random.Range(1, combinationCount);

        }
        if (combinationType >= 0 && combinationType < 65)
            direction = 1;
        else
            direction = -1;
        Debug.Log(newCombination[0]);
        for (int i = 1; i < combinationCount; i++)
        {
            if (i == revertIndex)
                direction *= -1;

            newCombination[i] = RatingCheck.NextState(newCombination[i - 1], direction);
            Debug.Log(newCombination[i]);
        }

        return newCombination;
    }


}
