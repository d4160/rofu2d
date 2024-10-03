using UnityEngine;

[System.Serializable]
public class ShootingState : CharacterStateBase
{
    public IShootingSkill ShootingSkill { get; set; }

    public override void Shoot(Vector2 targetPoint)
    {
        if (ShootingSkill != null)
        {
            ShootingSkill.Shoot(targetPoint);
        }


    }
}
