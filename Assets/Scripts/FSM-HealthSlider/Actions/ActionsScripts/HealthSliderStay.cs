using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/HealthSliderEffect/Actions/HealthSliderStay")]
public class HealthSliderStay : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("stay", true);
        controller.SetAnimation("increase", false);
    }
}
