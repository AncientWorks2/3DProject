using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/EnemyWarrior/Actions/Persecution")]
public class Persecution : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("patrol", false);
        controller.SetAnimation("persecution", true);
        controller.SetAnimation("die", false);
    }
}
