using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public int hp;
    public int attack;
    public int defense;

    public int range;
    public int aggroRange;

}
