using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingCheck
{
    public static Rank NextState(Rank currentState, int direction)
    {

        int nextIndex = System.Array.IndexOf(System.Enum.GetValues(typeof(Rank)), currentState) + direction;
        
        if (nextIndex == System.Enum.GetValues(typeof(Rank)).Length)
        {
            return (Rank)System.Enum.ToObject(typeof(Rank), nextIndex  % System.Enum.GetValues(typeof(Rank)).Length);
        }
        else if (nextIndex < 0)
        {
            return (Rank)System.Enum.ToObject(typeof(Rank), (nextIndex + System.Enum.GetValues(typeof(Rank)).Length) % System.Enum.GetValues(typeof(Rank)).Length);
        }
        else
        {
            return (Rank)System.Enum.ToObject(typeof(Rank), nextIndex);
        }
    }
}
