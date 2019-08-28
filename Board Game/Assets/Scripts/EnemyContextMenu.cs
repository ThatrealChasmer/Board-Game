using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyContextMenu : MonoBehaviour
{
    public GameObject enemy;
    public BattleManager battleManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !IsMouseOver())
        {
            enemy = null;
            gameObject.SetActive(false);
        }
    }

    public void OnAttackClick()
    {
        Debug.Log("Attack Clicked!");
        Debug.Log(GameObject.Find("Player").name);
        battleManager.AttackMob(GameObject.Find("Player"), enemy);
        gameObject.SetActive(false);
    }

    public bool IsMouseOver()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
