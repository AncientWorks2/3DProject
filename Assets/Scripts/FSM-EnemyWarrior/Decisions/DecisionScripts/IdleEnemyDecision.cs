using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/EnemyWarrior/Decision/Idle")]
public class IdleEnemyDecision : FSM.Decision
{
    public override bool Decide(Controller controller)
    {
        bool t = (controller.ReturnGuarding());

        return t;
    }
}
