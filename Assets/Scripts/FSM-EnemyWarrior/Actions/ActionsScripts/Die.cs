using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/EnemyWarrior/Actions/Die")]
public class Die : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("patrol", false);
        controller.SetAnimation("persecution", false);
        controller.SetAnimation("die", true);
    }
}
