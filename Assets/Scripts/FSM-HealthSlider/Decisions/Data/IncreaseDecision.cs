using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/HealthSliderEffect/Decision/IncreaseHealthSlider")]
public class IncreaseDecision : FSM.Decision
{
    public override bool Decide(Controller controller)
    {
        bool t = (CharacterHealthSystem.increase);

        return t;
    }
}
