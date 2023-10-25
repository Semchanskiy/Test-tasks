using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private PlayerController _player;

    public JumpState(PlayerController player)
    {
        _player = player;
    }
}
