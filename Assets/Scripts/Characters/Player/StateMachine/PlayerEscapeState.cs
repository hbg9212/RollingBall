using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEscapeState : PlayerGroundedState
{
    public PlayerEscapeState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        GameManager.Instance.levelPanel.SetActive(true);

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
