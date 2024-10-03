using System.Collections.Generic;
using Sirenix.OdinInspector;
using Newtonsoft.Json;

public class StateMachineBase<T> : ComponentBase, IStateMachine<T> where T : IState
{
    protected Dictionary<int, T> _activeStatesByLayer = new();

    public Dictionary<int, T> ActiveStatesByLayer => _activeStatesByLayer;

    [ShowInInspector]
    public string Debug => JsonConvert.SerializeObject(_activeStatesByLayer);

    public virtual void SetState(T newState)
    {
        if (_activeStatesByLayer.ContainsKey(newState.Layer))
        {
            if (!newState.Equals(_activeStatesByLayer[newState.Layer]))
            {
                _activeStatesByLayer[newState.Layer].OnExit();
                _activeStatesByLayer[newState.Layer] = newState;
                newState.OnEnter();
            }
        }
        else
        {
            _activeStatesByLayer.Add(newState.Layer, newState);
            newState.OnEnter();
        }
    }

    public void RemoveState(int layer)
    {
        if (_activeStatesByLayer.ContainsKey(layer))
        {
            _activeStatesByLayer[layer].OnExit();
            _activeStatesByLayer.Remove(layer);
        }
    }

    public T GetActiveState(int layer)
    {
        if (_activeStatesByLayer.ContainsKey(layer))
        {
            return _activeStatesByLayer[layer];
        }

        return default;
    }

    protected virtual void Update()
    {
        foreach (var state in _activeStatesByLayer)
        {
            state.Value.Update();
        }
    }
}

public interface IStateMachine<T> : IStateMachine where T : IState
{
    Dictionary<int, T> ActiveStatesByLayer { get; }

    void SetState(T newState);
    T GetActiveState(int layer);
}

public interface IStateMachine
{
    void RemoveState(int layer);
}
