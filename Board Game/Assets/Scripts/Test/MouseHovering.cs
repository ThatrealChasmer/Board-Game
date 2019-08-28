using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHovering : MonoBehaviour
{
    public bool hovering;
    public bool taken;
    public SpriteRenderer image;
    public GameObject player;
    public GameObject takenBy;
    public bool movable;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hovering)
        {
            if(movable)
            {
                player.GetComponent<PlayerMovement>().MoveToTarget(transform.position);
            }
            
        }
    }

    public void isMovable(bool state)
    {
        movable = state;
    }

    void OnMouseEnter()
    {
        if(movable)
        {
            hovering = true;
            Color tmp = image.color;
            tmp.a = 0.4f;
            image.color = tmp;
        }
        
    }

    void OnMouseExit()
    {
        hovering = false;
        Color tmp = image.color;
        tmp.a = 0.25f;
        image.color = tmp;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        taken = true;
        takenBy = collider.gameObject;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        taken = false;
    }
}
