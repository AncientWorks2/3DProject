using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingSystem : MonoBehaviour
{
    public Transform[] shotPoint;

    public int damage;

    public abstract void Shoot();
}
