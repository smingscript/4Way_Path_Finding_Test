using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGrid : MonoBehaviour
{

    public bool onlyDisplayPathGizmos;
    public LayerMask walkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public Node[,] Grid { get; private set; }

    public float nodeDiameter { get; private set; }
    public int gridSizeX { get; private set; }
    public int gridSizeY { get; private set; }

    private GameObject tileGroup;

    void Start()
    {
        tileGroup = GameObject.Find("TileGroup");

        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    public int MaxSize
    {
        get
        {
            return gridSizeX * gridSizeY;
        }
    }

    void CreateGrid()
    {
        Grid = new Node[gridSizeX, gridSizeY];

        Vector3 posVector = tileGroup.transform.position - (Vector3.right * gridWorldSize.x / 2 + Vector3.forward * gridWorldSize.y / 2);
        Vector3 worldBottomLeft = transform.position + posVector;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = Physics.CheckSphere(worldPoint, nodeRadius, walkableMask);
                Grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0 || x * y == -1 || x * y == 1)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(Grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }


    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (float)(worldPosition.x / gridWorldSize.x - 0.8);
        float percentY = (float)(worldPosition.z / gridWorldSize.y - 0.2);

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return Grid[x, y];
    }

    public List<Node> path;
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if (onlyDisplayPathGizmos)
        {
            if (path != null)
            {
                foreach (Node n in path)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
                }
            }
        }
        else
        {
            if (Grid != null)
            {
                foreach (Node n in Grid)
                {
                    Gizmos.color = (n.walkable) ? Color.white : Color.red;
                    if (path != null)
                        if (path.Contains(n))
                            Gizmos.color = Color.black;
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
                }
            }
        }
    }
}