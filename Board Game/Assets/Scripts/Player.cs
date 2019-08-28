using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    public int attack;
    public int defense;
    public int range;
    public int movePoints;
    public int movePointsLeft;
    public PlayerSO.Class playerClass;

    public PlayerSO so;

    // Start is called before the first frame update
    void Start()
    {
        hp = so.hp;
        attack = so.attack;
        defense = so.defense;
        range = so.range;
        movePoints = so.movePoints;
        movePointsLeft = movePoints;
        playerClass = so.characterClass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckIfInRange(GameObject target)
    {
        Debug.Log(target.name);
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range * 1.8f);
        Debug.Log(cols.Length);
        foreach(Collider2D col in cols)
        {
            Debug.Log(col.gameObject.name);
            if(col.gameObject == target)
            {
                Debug.Log("Found Enemy");
                return true;
            }
        }
        return false;
    }
}
