using System;
using UnityEngine;

public abstract class DataSOBase : ScriptableObject
{
    [SerializeField] private string _uid = Guid.NewGuid().ToString();
    [SerializeField] private string _name;
    [SerializeField] private string _category;

    public string Uid => _uid;
    public string Name => _name;
    public virtual string Type { get; protected set; } = "";
}
