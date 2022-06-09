using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/HealthSliderEffect/Actions/HealthSliderIncrease")]
public class HealthSliderIncrease : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("stay", false);
        controller.SetAnimation("increase", true);
    }
}
