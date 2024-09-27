using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UICollisionDetector detector;
    public GroupingCards gp;

    private void Start()
    {
        gp.GroupBy();
        detector.CheckCollision(gp.sortedCards);
    }
}
