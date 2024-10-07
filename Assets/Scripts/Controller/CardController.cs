using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerClickHandler
{
    private CardModel _model;
    private CardView _view;

    public void Initialize(CardModel model, CardView view)
    {
        _model = model;
        _view = view;
        view.Initialize(model);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_model.isOpen)
            return;
        if (Bank.instance.CheckCombination(_model.rank))
        {
            if (_model.childCard != null)
            {
                _model.childCard.isOpen = true;
            }
            Destroy(_model.gameObject);
        }
    }
    public void Set()
    {
        if (_model.isOpen)
            _view.faceUp.sprite = Resources.Load<Sprite>("Cards/Black" + _model.rank);
    }
}
