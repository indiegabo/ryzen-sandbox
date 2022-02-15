/// <summary>
///     Utility class to provide calculation static methods
/// </summary>
public class Calc
{

    /// <summary> This function converts a given value's scale into a given another</summary>
    /// <param name="value">The value wich should be rescaled</param>
    /// <param name="maxValue">The maximum value it would have on it's current scale</param>
    /// <param name="min">New scale minimum value</param>
    /// <param name="max">New scale maximum value</param>
    /// <returns>A float number representing the value rescaled</returns>
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

    /// <summary> This function converts a given value's scale into a given another</summary>
    /// <param name="value">The value wich should be rescaled</param>
    /// <param name="maxValue">The maximum value it would have on it's current scale</param>
    /// <param name="min">New scale minimum value</param>
    /// <param name="max">New scale maximum value</param>
    /// <param name="maxRounding"> A value to round up to max when met </param>
    /// <returns>A float number representing the value rescaled</returns>
    /// 
    public static float convertScale(float value, float maxValue, float min, float max, float maxRounding)
    {
        float delta = max - min;
        float converted = ((delta * value) + (min * maxValue)) / maxValue;
        if (converted > maxRounding)
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
