using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public GameObject child;
    public GameObject parent;
    public rating rat;
    public void OnPointerClick(PointerEventData eventData)
    {
        Controller.CheckCombination(rat);
    }
}
