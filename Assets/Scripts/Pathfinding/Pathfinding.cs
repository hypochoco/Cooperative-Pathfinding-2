using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {
    
    #region Pathfinding Variables

    // Constants for Calculations
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    // Pathfinding Variables
    private Grid<GridNode> _grid;
    private Heap<GridNode> _openList;
    private List<GridNode> _closedList;

    #endregion

    #region Constructor

    // Constructor
    public Pathfinding(Grid<GridNode> grid) {
        _grid = grid;
    }

    #endregion

    #region Pathfinding Functions

    // Calculate Distance Cost
    private int CalculateDistanceCost(GridNode start, GridNode end) {

        // Distances
        int xDistance = Mathf.Abs(start.x - end.x);
        int yDistance = Mathf.Abs(start.y - end.y);
        int zDistance = Mathf.Abs(start.z - end.z);
        
        // Min distance
        int minDistance = Mathf.Min(xDistance, yDistance, zDistance);

        // Distance between start and end nodes 
        return minDistance * MOVE_DIAGONAL_COST + 
            (xDistance + yDistance + zDistance - 3 * minDistance) *
            MOVE_STRAIGHT_COST;

    }

    // Calculate Path
    public List<GridNode> CalculatePath(GridNode endNode) {

        // Path
        List<GridNode> path = new List<GridNode>();

        // Current Node
        GridNode currentNode = endNode;
        path.Add(currentNode);

        // Trace through PreviousNodes until startNode reached
        while (currentNode.PreviousNode != null) {
            path.Insert(0, currentNode.PreviousNode);
            currentNode = currentNode.PreviousNode;
        }
        
        // Return Path
        return path;

    }

    // FindPath
    public List<GridNode> FindPath(int startX, int startY, int startZ,
        int endX, int endY, int endZ) { // RResTable<RGridNode> resTable, 
        
        // Initialize Start and End Nodes
        GridNode startNode = _grid.GetGridItem(startX, startY, startZ);
        GridNode endNode = _grid.GetGridItem(endX, endY, endZ);

        // Ensure Start and End Nodes exist
        if (startNode == null || endNode == null)
            return null;
        
        // Open and Closed List for A*
        _openList = new Heap<GridNode>(
            _grid.Array.GetLength(0) *
            _grid.Array.GetLength(1) *
            _grid.Array.GetLength(2) 
        );
        _closedList = new List<GridNode>();

        // Add startNode to openList
        _openList.Add(startNode);

        // Initialize all nodes
        foreach (GridNode node in _grid.Array) {

            if (node == null)
                continue;

            node.GCost = int.MaxValue;
            node.CalculateFCost();
            node.PreviousNode = null;
        }

        // Initialize Start Node
        startNode.GCost = 0;
        startNode.HCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        // Main Pathfinding Loop
        while (_openList.Count > 0) {
            
            // Find the node with the lowest value
            GridNode currentNode = _openList.RemoveFirst();

            // Check if endNode reached
            if (currentNode == endNode)
                return CalculatePath(endNode);

            // Add processed node to closedList
            _closedList.Add(currentNode);

            // Iterate through neighboring nodes
            foreach (GridNode neighborNode in 
                _grid.GetNeighbors(currentNode.x, currentNode.y, currentNode.z)) {

                // Stop if reserved
                // if (resTable.Reserved(neighborNode))
                //     continue;

                // Stop if in the closedList
                if (_closedList.Contains(neighborNode))
                    continue;

                // Stop if not walkable
                if (!neighborNode.Walkable)
                    continue;
                
                // Tentative gCost
                int tenativeGCost = currentNode.GCost + 
                    CalculateDistanceCost(currentNode, neighborNode);
                
                // If gCost is lower
                if (tenativeGCost < neighborNode.GCost) {

                    neighborNode.PreviousNode = currentNode;
                    neighborNode.GCost = tenativeGCost;
                    neighborNode.HCost = CalculateDistanceCost(neighborNode, endNode);
                    neighborNode.CalculateFCost();

                    if (!_openList.Contains(neighborNode))
                        _openList.Add(neighborNode);

                }
            }
        }

        // If path not found
        return null;

    }

    #endregion

}
