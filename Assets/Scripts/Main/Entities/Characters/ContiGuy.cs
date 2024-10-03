using UnityEngine;

[RequireComponent(typeof(SkillUser), typeof(Rigidbody2D), typeof(CharacterMachine))]
public class ContiGuy : CharacterBase
{
    [Header("References")]
    public CharacterMachine machine;

    [Header("Skills")]
    public FourDirectionalMove fourDirectionalMove;
    public DataBitShoot dataBitShoot;

    private SkillUser _skillUser;

    void Awake()
    {
        _skillUser = GetComponent<SkillUser>();

        if (!machine)
        {
            machine = GetComponent<CharacterMachine>();
        }
    }

    void Start()
    {
        _skillUser.AddSkill(fourDirectionalMove);
        _skillUser.AddSkill(dataBitShoot);

        machine.shootingState.ShootingSkill = dataBitShoot;

    }

    public void SetMoveInput(Vector2 movement)
    {
        fourDirectionalMove.Movement = movement;
        machine.Move(movement);
    }
}
