using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public int hp;
    public int attack;
    public int defense;
    public int range;
    public int aggroRange;

    public Enemy so;
    public GameObject ctxMenu;

    public bool hovering;

    // Start is called before the first frame update
    void Start()
    {
        hp = so.hp;
        attack = so.attack;
        defense = so.defense;
        range = so.range;
        aggroRange = so.aggroRange;
        //ctxMenu = GameObject.Find("EnemyContextMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && hovering)
        {
            ctxMenu.transform.position = Input.mousePosition;
            ctxMenu.GetComponent<EnemyContextMenu>().enemy = gameObject;
            ctxMenu.SetActive(true);
        }
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if(hp <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    void OnMouseEnter()
    {
        hovering = true;
    }

    void OnMouseExit()
    {
        hovering = false;
    }

    
}
