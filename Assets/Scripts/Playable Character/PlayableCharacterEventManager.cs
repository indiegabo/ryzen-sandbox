using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacterEventManager : MonoBehaviour
{
    // Event to be fired when character jumps
    public delegate void JumpStarted();
    public static event JumpStarted OnJumpStarted;

    // Call this to trigger the OnJumpStart Event
    public static void OnJumpStart()
    {
        OnJumpStarted();
    }
}

