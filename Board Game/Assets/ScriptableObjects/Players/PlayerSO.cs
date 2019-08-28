using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class PlayerSO : ScriptableObject
{
    public enum Class
    {
        Warrior,
        Ranger,
        Mage
    }

    public string playerName;
    public Class characterClass;
    public int hp;
    public int attack;
    public int defense;
    public int range;
    public int movePoints;
}
