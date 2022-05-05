using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Button/Actions/ButtonOff")]
public class ButtonOff : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("buttonOn", false);
        controller.SetAnimation("buttonOff", true);
    }
}
