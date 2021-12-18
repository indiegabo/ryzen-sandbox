public interface IPlayableCharacterController
{
    bool grounded { get; set; }
    bool engagedOnAttack { get; set; }
    void JumpStarted();
    void ChangeState(string stateName);
    float CurrentAnimationDuration();

}
