using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{

    /// <summary> This function converts a given value's scale into a given another </summary>
    /// <returns> A float number representing the value rescaled </returns>
    /// <param name="value"> 
    ///     The value wich should be rescaled 
    /// </param>
    /// <param name="maxValue"> The maximum value it would have on it's current scale </param>
    /// <param name="min"> New scale minimum value </param>
    /// <param name="max"> New scale maximum value </param>
    public static float convertScale(float value, float maxValue, float min, float max)
    {
        float delta = max - min;
        float converted = ((delta * value) + (min * maxValue)) / maxValue;
        if (converted > max)
        {
            return max;
        }
        else if (converted < min)
        {
            return min;
        }
        return converted;
    }
}
