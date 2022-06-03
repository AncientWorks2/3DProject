using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/HealthEffect/Actions/HealthEffectOn")]
public class HealthEffectOn : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("hit", true);
        controller.SetAnimation("noHit", false);
    }
}
