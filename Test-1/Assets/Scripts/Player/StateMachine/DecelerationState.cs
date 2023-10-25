using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecelerationState : State
{
    private PlayerController _player;
    [SerializeField] private float _timeToIdle = 0.5f; // время после которого при не зажатом джойстике игрок перейдет в состояние покоя
    private float _remainingTimeToIdle; //таймер от _timeToIdle

    public DecelerationState(PlayerController player)
    {
        _player = player;
    }
    public override void Enter()
    {
        base.Enter();
        _remainingTimeToIdle = 0f; // при входе в состояние сбрасываем таймер
        _player.PlayerView.Animator.CrossFade("Player_Decelebration", 0f);
    }

    public override void Update()
    {
        base.Update();
        Deceleration(); //если джойстик отпущен постепенно уменьшает скорость персонажа
        CheckState(); // проверяет условия для смены состояния
    }

    public void Deceleration()
    {
        if (_player._moveInput.x == 0)
        {
            float currentSpeed = _player._rb.velocity.x;
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, _player.PlayerModel._decelerationSpeed * Time.deltaTime);
            {
                _player._rb.velocity = new Vector2(currentSpeed, 0);
            }
        }
    }

    public override void CheckState()
    {
        #region ToIdleState and ToWalkState 
        if (_player._moveInput.x == 0)
        {
            _remainingTimeToIdle += Time.deltaTime;
            if (_remainingTimeToIdle >= _timeToIdle)
            {
                _player._SM.ChangeState(_player._idleState); 
            }
        }
        else
        {
            _player._SM.ChangeState(_player._walkState);
        }
        #endregion

        #region ToOffsetState
        if (_player._moveInput.y != 0)
        {
            if (_player._moveInput.y > 0 && _player.PlayerModel._numberCurrentLine <= 2 || _player._moveInput.y < 0 && _player.PlayerModel._numberCurrentLine >= 2)
            {
                _player._SM.ChangeState(_player._offsetState);
            }
        }
        #endregion
    }

    public override void Exit()
    {
        base.Exit();
    }
}
