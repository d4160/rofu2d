using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : ProjectileBase
{
    private Rigidbody2D _rb2D;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    public override void SetDirectionAndSpeed(Vector2 direction, float speed)
    {
        _rb2D.linearVelocity = direction.normalized * speed;
    }
}
