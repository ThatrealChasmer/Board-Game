using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    public GameObject currentTile;
    public bool isMoving;
    public List<GameObject> neighbourTiles = new List<GameObject>();
    public List<GameObject> movableTiles = new List<GameObject>();
    public Player player;
    public Cover cover;

    // Start is called before the first frame update
    void Start()
    {
        CheckCurrentTile();
        CheckNeighbours();
        CheckMovingRange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCurrentTile()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        foreach (Collider2D col in cols)
        {
            if (col.CompareTag("Tile"))
            {
                currentTile = col.gameObject;
            }
        }
    }
    public void CheckNeighbours()
    {
        neighbourTiles.Clear();
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 1.8f);

        foreach(Collider2D col in cols)
        {
            if (col.gameObject.CompareTag("Tile") && col.transform.position != transform.position && (col.gameObject.GetComponent<MouseHovering>().taken == false || col.gameObject.GetComponent<MouseHovering>().takenBy == gameObject))
            {
                neighbourTiles.Add(col.gameObject);
            }
        }
    }

    public void MoveToTarget(Vector3 target)
    {
        if(!isMoving)
        {
            StartCoroutine(Move(target));
        }
    }

    IEnumerator Move(Vector3 target)
    {
        isMoving = true;
        while(transform.position != target)
        {
            GameObject minTile = neighbourTiles[0];
            float minDist = 50;
            foreach (GameObject tile in neighbourTiles)
            {
                if (Vector3.Distance(tile.transform.position, target) < minDist)
                {
                    minTile = tile;
                    minDist = Vector3.Distance(tile.transform.position, target);
                }
            }

            Debug.Log(minTile.name + ": " + minDist);
            yield return StartCoroutine(MoveOne(minTile.transform.position, 0.2f));
            
        }
        CheckCurrentTile();
        CheckMovingRange();
        isMoving = false;
        
    }

    IEnumerator MoveOne(Vector3 newPosition, float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        CheckNeighbours();
        cover.CheckForCovers();
    }

    public void CheckMovingRange()
    {
        for(int i = movableTiles.Count - 1; i >= 0; i--)
        {
            movableTiles[i].GetComponent<MouseHovering>().isMovable(false);
            movableTiles.RemoveAt(i);
        }
        List<GameObject> toCheck = new List<GameObject>();
        List<GameObject> newCheck = new List<GameObject>();
        toCheck.Add(currentTile);
        for(int i = 0; i < player.movePointsLeft; i++)
        {
            Debug.Log(toCheck.Count);
            foreach(GameObject tile in toCheck)
            {
                List<GameObject> tmp = GetFieldNeighbours(tile);
                Debug.Log(tmp.Count);
                newCheck = newCheck.Union(tmp).ToList();
            }
            Debug.Log(newCheck.Count);
            movableTiles = movableTiles.Union(newCheck).ToList();
            Debug.Log(movableTiles.Count);
            toCheck.Clear();
            toCheck.AddRange(newCheck);
            newCheck.Clear();
        }
        
    }

    public List<GameObject> GetFieldNeighbours(GameObject field)
    {
        List<GameObject> neighbours = new List<GameObject>();
        Collider2D[] cols = Physics2D.OverlapCircleAll(field.transform.position, 1.8f);
        foreach(Collider2D col in cols)
        {
            if (col.CompareTag("Tile") && col.gameObject != field && col.GetComponent<MouseHovering>().taken == false)
            {
                col.gameObject.GetComponent<MouseHovering>().isMovable(true);
                neighbours.Add(col.gameObject);
            }
        }

        return neighbours;
    }
}
