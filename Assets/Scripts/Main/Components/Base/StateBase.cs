using UnityEngine;

[System.Serializable]
public abstract class StateBase : IState
{
    [SerializeField] protected int _layer;

    public int Layer => _layer;

    public IStateMachine StateMachine { get; set; }

    public virtual void OnEnter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void OnExit()
    {

    }
}

public interface IState
{
    int Layer { get; }
    IStateMachine StateMachine { get; set; }

    void OnEnter();
    void Update();

    void OnExit();
}
