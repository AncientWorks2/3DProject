using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/HealthEffect/Decision/HitOn")]

public class HitOnDecision : FSM.Decision
{
    public override bool Decide(Controller controller)
    {
        bool t = (CharacterHealthSystem.hit);

        return t;
    }
}
