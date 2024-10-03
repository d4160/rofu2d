using UnityEngine;

[System.Serializable]
public class DeadState : CharacterStateBase
{
    public override void OnEnter()
    {
        CharacterMachine.RemoveState(1);
        CharacterMachine.RemoveState(2);
    }


}
