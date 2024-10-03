using UnityEngine;

/// <summary>
/// Clase base abstracta para todas las habilidades.
/// </summary>
[System.Serializable]
public abstract class SkillBase : ISkill
{
    public bool Enabled { get; set; } = true;
    public SkillUser SkillUser { get; set; }

    public T GetComponent<T>()
    {
        if (SkillUser)
        {
            return SkillUser.GetComponent<T>();
        }

        Debug.LogError($"SkillUser not found in {GetType()}");

        return default;
    }

    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Execute() { }
}

public interface ISkill
{
    bool Enabled { get; set; }
    SkillUser SkillUser { get; set; }

    T GetComponent<T>();

    void Start();
    void Update();
    void FixedUpdate();
    void Execute();
}