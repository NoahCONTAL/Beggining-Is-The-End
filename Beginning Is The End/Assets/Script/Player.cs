using System;
using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] internal int health = 50;
    [SerializeField] internal int maxHealth = 100;
    [SerializeField] internal int energy = 100;
    [SerializeField] internal int maxEnergy  = 100;
    [SerializeField] private int damage = 5;
}
