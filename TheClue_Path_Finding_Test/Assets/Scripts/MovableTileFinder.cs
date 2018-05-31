using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableTileFinder : MonoBehaviour
{
    public int DiceNumber = 5;
    TileGrid grid;

    private void Awake()
    {
        grid = GameObject.Find("A*PathFinder").GetComponent<TileGrid>();
    }

    private void Update()
    {
        FindTiles();
    }

    List<Node> movableTiles;

    public void FindTiles()
    {
        Node HorsePosNode = grid.NodeFromWorldPoint(transform.position);
        //print("Grid X: " + grid.gridSizeX + "Grid Y: " + grid.gridSizeY);

        movableTiles = TileFinder.GetMovableTiles(HorsePosNode, DiceNumber, grid);
    }

    private void OnDrawGizmos()
    {
        if(movableTiles != null)
        {
            foreach (Node tile in movableTiles)
            {
                //if (tile.walkable)
                //    Gizmos.color = Color.black;
                Gizmos.color = (tile.walkable) ? Color.blue : Color.red;
                Gizmos.DrawCube(tile.worldPosition, Vector3.one * (grid.nodeDiameter - .1f));
            }
        }
    }
}
