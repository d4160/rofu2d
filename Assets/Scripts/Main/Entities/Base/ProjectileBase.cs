using UnityEngine;

public class ProjectileBase : EntityBase, IProjectile
{
    public virtual void SetDirectionAndSpeed(Vector2 direction, float speed) { }
}

public interface IProjectile
{
    void SetDirectionAndSpeed(Vector2 direction, float speed);
}
