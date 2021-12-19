using UnityEngine;

public class PlayableCharacterEventManager : MonoBehaviour
{
    // Event to be fired when character jumps
    public delegate void PlayableCharacterJumpStarted(GameObject jumpingChararacter);
    public static event PlayableCharacterJumpStarted OnPlayableCharacterJumpStarted;

    // Call this to trigger the OnJumpStart Event
    public static void OnPLayableCharacterJumpStart(GameObject jumpingChararacter)
    {
        OnPlayableCharacterJumpStarted(jumpingChararacter);
    }
}

