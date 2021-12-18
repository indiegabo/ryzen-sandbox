
public interface IPlayableCharacterState
{
    void ChangeState(string newStateName);
    float CurrentAnimationDuration();
}
