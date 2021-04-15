using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Create Enemy Data", order = 0)]
public class EnemyData : ScriptableObject
{
    public int Value;
    public int Health;
    public float Speed;
}
