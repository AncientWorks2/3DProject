using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/EnemyWarrior/Actions/Idle")]
public class IdleEnemy : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", true);
        controller.SetAnimation("patrol", false);
        controller.SetAnimation("persecution", false);
        controller.SetAnimation("die", false);
    }
}
