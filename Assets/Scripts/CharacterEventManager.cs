using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEventManager : MonoBehaviour
{
    public delegate void JumpStarted();
    public static event JumpStarted OnJumpStart;

    public static void OnJump()
    {
        if (OnJumpStart != null)
            OnJumpStart();
    }
}

