using UnityEngine;

public abstract class InputBase<T> : ComponentBase, IInput where T : Component
{
    protected T _entity;

    protected virtual void Awake()
    {
        _entity = GetComponent<T>();
    }
}

public interface IInput
{

}
