using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/StaminaSlider/Actions/StaminaSliderStay")]
public class StaminaSliderStay : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("change", false);
        controller.SetAnimation("stay", true);
    }
}
