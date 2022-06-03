using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/HealthEffect/Actions/HealthEffectOff")]
public class HealthEffectOff : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("hit", false);
        controller.SetAnimation("noHit", true);
    }
}
