using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : InteractManager
{
    [SerializeField]
    private Transform ballHolder;
    [SerializeField]
    private Transform[] balls;
    private int numBalls = 4;

    void Respawning()
    {
        balls[0].position = ballHolder.position;
        balls[1].position = ballHolder.position;
        balls[2].position = ballHolder.position;
        balls[3].position = ballHolder.position;


    }

    public override string GetDescription()
    {
        return " Press [E] to respawn the balls";
    }

    public override void Interact()
    {
        Respawning();

    }
}
