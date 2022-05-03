using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/EnemyWarrior/Decision/Persecution")]
public class PersecutionDecision : FSM.Decision
{
    public override bool Decide(Controller controller)
    {
        bool t = (controller.ReturnSeeing());

        return t;
    }
}
