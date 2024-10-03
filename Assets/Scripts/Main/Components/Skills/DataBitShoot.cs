using UnityEngine;

[System.Serializable]
public class DataBitShoot : ShootingSkillBase
{
    public float projectileSpeed = 5.5f;

    [Header("References")]
    public Projectile prefab;
    public Transform shootPoint;

    public override void Shoot(Vector2 targetPoint)
    {
        if (prefab && shootPoint)
        {
            Projectile projectile = InstantiateProjectile();
            Vector3 projectilePos = projectile.transform.position;

            Vector2 direction = targetPoint - new Vector2(projectilePos.x, projectilePos.y);
            direction.Normalize();

            projectile.transform.forward = direction;
            projectile.SetDirectionAndSpeed(direction, projectileSpeed);
        }
        else
        {
            Debug.LogError($"({nameof(ShootingState)}) Prefab and ShootPoint are null");
        }
    }

    private Projectile InstantiateProjectile()
    {
        return SkillUser.Instantiate(prefab, shootPoint.position, shootPoint.rotation);
    }
}
