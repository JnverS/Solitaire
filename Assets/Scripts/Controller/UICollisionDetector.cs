using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollisionDetector : MonoBehaviour
{
    public RectTransform element1;
    public RectTransform element2;

    void Update()
    {
        
    }

    public bool IsOverlapping(RectTransform rect1, RectTransform rect2)
    {
        return rect1.rect.Overlaps(rect2.rect);
    }
}
