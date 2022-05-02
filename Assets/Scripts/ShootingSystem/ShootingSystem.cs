using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingSystem : MonoBehaviour
{
    public Transform[] shotPoint;

    public abstract void Shoot();
}
