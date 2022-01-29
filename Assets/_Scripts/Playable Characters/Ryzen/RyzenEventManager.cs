using UnityEngine;

public class RyzenEventManager : MonoBehaviour
{
    // Event to be fired when character jumps
    public delegate void RyzenJumped(GameObject chararacter);
    public static event RyzenJumped OnRyzenJumped;

    // Call this to trigger the PlayableCharacterJumped Event
    public static void RyzenJumping(GameObject ryzen)
    {
        if (ryzen == null)
            return;
        if (OnRyzenJumped != null)
            OnRyzenJumped(ryzen);
    }

    // Event to be fired when character dashes
    public delegate void RyzenDashed(GameObject chararacter);
    public static event RyzenDashed OnRyzenDashed;

    // Call this to trigger the OnJumpStart Event
    public static void PlaybleCharacterDashing(GameObject ryzen)
    {
        if (ryzen == null)
            return;
        if (OnRyzenDashed != null)
            OnRyzenDashed(ryzen);
    }

}

