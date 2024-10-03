using UnityEngine;

public abstract class ManagerBase<T> : SingletonBase<T>, IManager where T : ManagerBase<T>
{

}

public interface IManager
{

}
