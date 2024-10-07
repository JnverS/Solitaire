using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public Image faceUp;
    private CardModel _model;

    public void Initialize(CardModel model)
    {
        _model = model;
        faceUp = GetComponent<Image>();
    }
    
}
