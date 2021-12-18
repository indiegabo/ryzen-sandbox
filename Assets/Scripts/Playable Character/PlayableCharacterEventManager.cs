using UnityEngine;

public class PlayableCharacterEventManager : MonoBehaviour
{
    // Event to be fired when character jumps
    public delegate void JumpStarted(GameObject jumpingChararacter);
    public static event JumpStarted OnJumpStarted;

    // Call this to trigger the OnJumpStart Event
    public static void OnJumpStart(GameObject jumpingChararacter)
    {
        OnJumpStarted(jumpingChararacter);
    }
}

