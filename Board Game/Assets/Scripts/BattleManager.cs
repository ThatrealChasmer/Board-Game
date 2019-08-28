using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackMob(GameObject attacker, GameObject receiver)
    {
        if(attacker.GetComponent<Player>().CheckIfInRange(receiver))
        {
            int startingDmg = attacker.GetComponent<Player>().attack;
            int enemyDef = receiver.GetComponent<EnemyBehaviour>().defense;

            int toDeal = startingDmg - enemyDef / 2;

            receiver.GetComponent<EnemyBehaviour>().TakeDamage(toDeal);
        }
        else
        {
            Debug.Log("Target not in range!");
        }
    }
}
