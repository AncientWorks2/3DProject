using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/StaminaSlider/Actions/StaminaSliderChange")]
public class StaminaSliderChange : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("change", true);
        controller.SetAnimation("stay", false);
    }
}
