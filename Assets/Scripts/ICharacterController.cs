public interface ICharacterController
{   
    bool grounded {get; set;}
    bool engagedOnAttack {get; set;}
    void ChangeState(string stateName);
    float CurrentAnimationDuration();
}
