using UnityEngine;

public class PlayableCharacterEventManager : MonoBehaviour
{
    // Event to be fired when character jumps
    public delegate void PlayableCharacterJumped(GameObject chararacter);
    public static event PlayableCharacterJumped OnPLayableCharacterJumped;

    // Call this to trigger the PlayableCharacterJumped Event
    public static void PlaybleCharacterJumping(GameObject chararacter)
    {
        if (chararacter == null)
            return;
        if (OnPLayableCharacterJumped != null)
            OnPLayableCharacterJumped(chararacter);
    }

    // Event to be fired when character dashes
    public delegate void PlayableCharacterDashed(GameObject chararacter);
    public static event PlayableCharacterDashed OnPlayableCharacterDashed;

    // Call this to trigger the OnJumpStart Event
    public static void PlaybleCharacterDashing(GameObject chararacter)
    {
        if (chararacter == null)
            return;
        if (OnPlayableCharacterDashed != null)
            OnPlayableCharacterDashed(chararacter);
    }

}

