using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Button/Actions/ButtonOn")]
public class ButtonOn : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("buttonOn", true);
        controller.SetAnimation("buttonOff", false);
    }
}
