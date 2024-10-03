using UnityEngine;

[System.Serializable]
public class LocomotionState : CharacterStateBase
{
    public float downwardsYOffset = 0.1531f;

    [Header("References")]
    public Transform graphics;
    public ParticleSystem moveDust;

    public override void Move(Vector2 movement)
    {
        Turn(movement);

        CharacterMachine.animator.SetFloat(CharacterMachine.HSpeedHash, movement.x);
        CharacterMachine.animator.SetFloat(CharacterMachine.VSpeedHash, movement.y);

        if (movement.x != 0)
        {
            if (!moveDust.isPlaying)
            {
                moveDust.Play();
            }
        }
        else
        {
            moveDust.Stop();
        }
    }

    private void Turn(Vector2 direction)
    {
        var scale = graphics.transform.localScale;

        scale.x = Mathf.Sign(direction.x) * Mathf.Abs(scale.x);
        scale.y = Mathf.Sign(direction.y) * Mathf.Abs(scale.y);

        if (direction.x != 0)
        {
            scale.y = Mathf.Abs(scale.y);
        }

        if (scale.y < 0)
        {
            graphics.transform.localPosition = Vector3.up * downwardsYOffset;
        }
        else
        {
            graphics.transform.localPosition = Vector3.zero;
        }

        graphics.transform.localScale = scale;
    }
}
