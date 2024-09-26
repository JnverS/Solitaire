using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller 
{
    protected View _view;
    protected Model _model;

    public Controller(View view, Model model)
    {
        _view = view;
        _model = model;
    }

    public static void CheckCombination(rating rat)
    {
        
    }

    //generator
    //mover
    //result
}
