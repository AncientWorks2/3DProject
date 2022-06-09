using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/StaminaSlider/Decision/StaminaSliderStayDecision")]
public class StaminaSliderStayDecision : FSM.Decision
{
    public override bool Decide(Controller controller)
    {
        bool t = (!StaminaSystem.increase && !StaminaSystem.decrease);

        return t;
    }
}