
public interface IStateManager
{
    bool ChangeState(string newStateName);
    float CurrentAnimationDuration();
}
