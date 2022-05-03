using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/EnemyWarrior/Decision/Die")]
public class DieDecision : FSM.Decision
{
    public override bool Decide(Controller controller)
    {
        bool t = (true);

        return t;
    }
}
