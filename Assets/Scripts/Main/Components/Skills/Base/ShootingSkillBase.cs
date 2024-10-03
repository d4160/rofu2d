using UnityEngine;

[System.Serializable]
public class ShootingSkillBase : SkillBase, IShootingSkill
{
    public virtual void Shoot(Vector2 targetPoint) { }
}

public interface IShootingSkill : ISkill
{
    void Shoot(Vector2 targetPoint);
}
