using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    private PlayerController _player;

    public WalkState(PlayerController player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerView.Animator.CrossFade("Player_Walk", 0f); 
    }

    public override void Update()
    {
        base.Update();
        Move(); // меняет скорость игрока в зависимости от того куда был направлен джойстик
        CheckFlip(); // меняет направление игрока в зависимости от того куда был направлен джойстик в последний момент
        CheckState(); // проверяет условия для смены состояния
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

    public void Move()
    {
        if (Mathf.Abs(_player._moveInput.x) > 0)
        {
            _player._rb.velocity = new Vector2(_player.PlayerModel._walkSpeed * _player._moveInput.x, _player._rb.velocity.y);
        }
    }

    public override void CheckState()
    {
        #region ToDecelerateState
        if (_player._moveInput.x == 0)
        {
            _player._SM.ChangeState(_player.DecelerationState);
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
