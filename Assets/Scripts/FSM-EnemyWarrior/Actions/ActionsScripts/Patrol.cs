using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/EnemyWarrior/Actions/Patrol")]
public class Patrol : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("patrol", true);
        controller.SetAnimation("persecution", false);
        controller.SetAnimation("die", false);
    }
}
