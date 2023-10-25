using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerView PlayerView; 
    [HideInInspector] public PlayerModel PlayerModel;

    [HideInInspector] public Rigidbody2D _rb;
    [HideInInspector] public Transform _transform;

    #region StateMachine
    [HideInInspector] public StateMachinePlayer _SM;
    [HideInInspector] public IdleState _idleState;
    [HideInInspector] public WalkState _walkState;
    [HideInInspector] public JumpState _jumpState; // JumpState на будущее. В дальшейшем будут состояния получения урона, удара, взаимодействия с объектами.
    [HideInInspector] public OffsetState _offsetState;
    [HideInInspector] public DecelerationState DecelerationState;
    #endregion

    #region Input
    private PlayerInput _input;
    [HideInInspector] public Vector2 _moveInput;
    #endregion

    void Awake()
    {
        _input = new PlayerInput();
        PlayerView = GetComponent<PlayerView>();
        PlayerModel = GetComponent<PlayerModel>();

        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();

        _SM = new StateMachinePlayer();
        _offsetState = new OffsetState(this);
        _jumpState = new JumpState(this);
        DecelerationState = new DecelerationState(this);
        _walkState = new WalkState(this);
        _idleState = new IdleState(this);
    }
    void Start()
    {
        _SM.Initialize(_idleState);
    }

    private void Move()
    {

    }

    void Update()
    {
        _moveInput = _input.Player.Move.ReadValue<Vector2>();
        _SM.CurrentState.Update();
    }

    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }


}
