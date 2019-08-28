using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tile", menuName = "MapTile")]
public class Tile : ScriptableObject
{
    public enum TileType
    {
        Forest,
        Mountain
    }

    bool block;

    bool starting;
}
