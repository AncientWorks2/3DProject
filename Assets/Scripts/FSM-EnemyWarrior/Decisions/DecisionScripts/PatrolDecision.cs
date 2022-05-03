using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/EnemyWarrior/Decision/Patrol")]
public class PatrolDecision : FSM.Decision
{
    public override bool Decide(Controller controller)
    {
        bool t = (controller.ReturnPatroling());

        return t;
    }
}
