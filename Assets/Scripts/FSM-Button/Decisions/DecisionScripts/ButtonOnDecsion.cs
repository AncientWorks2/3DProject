using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Button/Decision/ButtonOn")]
public class ButtonOnDecsion : FSM.Decision
{
    public override bool Decide(Controller controller)
    {
        bool t = (controller.ReturnOn());

        return t;
    }
}
