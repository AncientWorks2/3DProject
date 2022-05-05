using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private int openTargetSpeed;
    [SerializeField]
    private int closeTargetSpeed;

    private HingeJoint _joint;
    private ButtonController _buttContr;
    private JointMotor motor;

    private void Awake()
    {
        _joint = GetComponent<HingeJoint>();
        motor = _joint.motor;

        _buttContr = button.GetComponent<ButtonController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_buttContr.ReturnInOn())
        {
            motor.targetVelocity = openTargetSpeed;

            _joint.motor = motor;
        }
        else
        {
            motor.targetVelocity = closeTargetSpeed;

            _joint.motor = motor;
        }
    }
}
