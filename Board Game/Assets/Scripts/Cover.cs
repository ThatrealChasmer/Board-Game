 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    void Start()
    {
        CheckForCovers();
    }
    
    public void CheckForCovers()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 3.6f);
        foreach(Collider2D col in cols)
        {
            if (col.CompareTag("Cover") && Vector2.Distance(transform.position, col.transform.position) <= 4f)
            {
                Destroy(col.gameObject);
            }
        }
    }
}
