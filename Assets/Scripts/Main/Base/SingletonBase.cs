using UnityEngine;

public abstract class SingletonBase<T> : MonoBehaviour, ISingleton where T : MonoBehaviour
{
    private static T s_instance;

    public static T Instance
    {
        get => s_instance;
        protected set => s_instance = value;
    }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else
        {
            Destroy(this);
        }
    }
}


public interface ISingleton
{

}