using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using DG.Tweening;

public class OffsetState : State
{
    private PlayerController _player;
    private float _timeOffset = 1f; // ����� �������� � ����� ����� �� ������

    public OffsetState(PlayerController player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        _player._rb.velocity = Vector2.zero; // �� ������ ������ ������� ��� ����
        _player.PlayerView.ChangeScale(_player._moveInput.y); // �������� ����� ��������� ������� ���������
        Offset();
    }
    public override void Update()
    {
        base.Update();
    }
    private void Offset() // ����������� ������ �������� � ���� ������ ��������� �� ����� ����� �� ���������
    {
        if (_player._moveInput.y > 0)
        {
            _player.PlayerModel._numberCurrentLine++;
            _player.PlayerView.Animator.CrossFade("Player_Offset_Up", 0f);
        }
        else if (_player._moveInput.y < 0)
        {
            _player.PlayerModel._numberCurrentLine--;
            _player.PlayerView.Animator.CrossFade("Player_Offset_Down", 0f);
        }

#pragma warning disable CS4014 // ��� ��� ���� ����� �� ���������, ���������� ������������� ������ ������������ �� ��� ���, ���� ����� �� ����� ��������
        Wait(_timeOffset);
#pragma warning restore CS4014 // ��� ��� ���� ����� �� ���������, ���������� ������������� ������ ������������ �� ��� ���, ���� ����� �� ����� ��������
        _player._transform.DOMoveY(_player._transform.position.y + _player._moveInput.y, _timeOffset).SetEase(Ease.Linear); //���������� ��������� �� ������ �����



    }

    private async Task Wait(float time)
    {
        await Task.Delay(TimeSpan.FromSeconds(time)); //����� ���������� �������� �������� �� ��������� ������� ������,���� ������ ���-�� �������
        CheckState(); // �������� ����� �������� ��������� �� ���� ���� �������� ����� ������������ �� ���� ������, ���� ������ � ��������� �����
    }

    public override void CheckState()
    {
        #region ToOffsetState
        if (_player._moveInput.y != 0)
        {
            if (_player._moveInput.y > 0 && _player.PlayerModel._numberCurrentLine <= 2 || _player._moveInput.y < 0 && _player.PlayerModel._numberCurrentLine >= 2)
            {
                _player._SM.ChangeState(_player._offsetState);
            }
        }
        else
        {
            _player._SM.ChangeState(_player._idleState);
        }
        #endregion
    }

    public override void Exit()
    {
        base.Exit();
    }
}
