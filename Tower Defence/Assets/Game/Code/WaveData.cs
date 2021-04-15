﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Create Wave Data", order = 0)]
public class WaveData : ScriptableObject
{
    public GameObject[] Enemies;
}
