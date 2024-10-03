using UnityEngine;

[System.Serializable]
public abstract class CharacterStateBase : StateBase, ICharacterState
{
    public CharacterMachine CharacterMachine => StateMachine as CharacterMachine;

    public virtual void Move(Vector2 movement)
    {

    }

    public virtual void Shoot(Vector2 targetPoint)
    {

    }

    public virtual void Kill()
    {

    }

    public virtual void Revive()
    {

    }
}

public interface ICharacterState : IState
{
    CharacterMachine CharacterMachine { get; }

    void Move(Vector2 movement);

    void Shoot(Vector2 targetPoint);

    void Kill();

    void Revive();
}