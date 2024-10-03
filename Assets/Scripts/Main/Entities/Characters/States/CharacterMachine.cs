using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterMachine : StateMachineBase<ICharacterState>
{
    [Header("References")]
    public Animator animator;

    [Header("Available States")]
    public AliveState aliveState;
    public DeadState deadState;
    public LocomotionState locomotionState;
    public ShootingState shootingState;
    public MeleeAttackState meleeAttackState;

    private int _hSpeedHash = -1;
    private int _vSpeedHash = -1;

    public int HSpeedHash => _hSpeedHash != -1 ? _hSpeedHash : Animator.StringToHash("HSpeed");
    public int VSpeedHash => _vSpeedHash != -1 ? _vSpeedHash : Animator.StringToHash("VSpeed");

    void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Start()
    {
        aliveState.StateMachine = this;
        deadState.StateMachine = this;
        locomotionState.StateMachine = this;
        shootingState.StateMachine = this;
        meleeAttackState.StateMachine = this;

        SetState(aliveState);
        SetState(locomotionState);
    }

    public void Move(Vector2 movement)
    {
        GetActiveState(locomotionState.Layer)?.Move(movement);
    }

    public void Shoot(Vector2 targetPoint)
    {
        SetState(shootingState);
        GetActiveState(shootingState.Layer)?.Shoot(targetPoint);
    }
}
