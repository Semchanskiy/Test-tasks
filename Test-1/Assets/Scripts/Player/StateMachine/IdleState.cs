using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private PlayerController _player;
    [SerializeField] private const float _timeToWalk = 0.25f; //минимальное время на которое нужно отклонить стик, чтобы персонаж начал движение
    private float _remainingTimeToWalk;

    public IdleState(PlayerController player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerView.Animator.CrossFade("Player_Idle",0.1f);
        _remainingTimeToWalk = 0;
        _player._rb.velocity = Vector2.zero;
    }

    public override void Update()
    {
        base.Update();
        CheckFlip(); 
        CheckState();
    }

    public void CheckFlip()
    {
        if (_player._moveInput.x > 0 && _player.PlayerView._isFacingRight == false)
        {
            _player.PlayerView.Flip();
        }
        else if (_player._moveInput.x < 0 && _player.PlayerView._isFacingRight == true)
        {
            _player.PlayerView.Flip();
        }
    }

    public override void CheckState()
    {
        base.CheckState();

        #region ToWalkState
        if (Math.Abs(_player._moveInput.x) > 0)
        {
            _remainingTimeToWalk += Time.deltaTime;
            if (_remainingTimeToWalk >= _timeToWalk)
            {
                _player._SM.ChangeState(_player._walkState);
            }
        }
        else
        {
            _remainingTimeToWalk = 0;
        }
        #endregion

        #region ToOffsetState
        if (_player._moveInput.y != 0)
        {
            if (_player._moveInput.y > 0 && _player.PlayerModel._numberCurrentLine <= 2|| _player._moveInput.y < 0 && _player.PlayerModel._numberCurrentLine >= 2)
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
