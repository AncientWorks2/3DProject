using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    public float health;

    public float maxHealth;

    public abstract void RestHealth(int restHealthValue);
}