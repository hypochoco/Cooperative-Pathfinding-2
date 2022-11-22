using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingComponent : MonoBehaviour {

    [SerializeField] private GridComponent _gridComponent;
    private Grid<GridNode> _grid;
    private Pathfinding _pathfinding;

    private void Start() {
        _grid = _gridComponent.grid;
        _pathfinding = new Pathfinding(_grid);
    }

    // Pathfinding from Vector3 positions
    public List<Vector3> FindPath(Vector3 startPosition, Vector3 endPosition) {
        
        (int, int, int) coordinateStartPosition = 
            _grid.GetCoord(startPosition);
        (int, int, int) cooridnateEndPosition = 
            _grid.GetCoord(endPosition);

        // Get some kind of function, maybe called in grid bounds or something
        // and maybe another function to find the nearest point in the grid
        // bounds or something... 

        List<GridNode> gridNodePath = _pathfinding.FindPath(
            coordinateStartPosition.Item1,
            coordinateStartPosition.Item2,
            coordinateStartPosition.Item3,
            cooridnateEndPosition.Item1,
            cooridnateEndPosition.Item2,
            cooridnateEndPosition.Item3);

        if (gridNodePath == null) {
            Debug.Log("No path found!");
            return null;
        }

        List<Vector3> path = new List<Vector3>();
        gridNodePath.RemoveAt(0);
        foreach (GridNode gridNode in gridNodePath) {
            path.Add(_grid.GetWorld(gridNode.x, gridNode.y, gridNode.z));
        }

        return path;
    }

    // pathfinding test
    public void TestPathfinding(
        AgentController agentController, Vector3 targetPosition) {

        Vector3 pos = agentController.agent.transform.position
            + 0.125f * Vector3.down;
        (int, int, int) startPosition = 
            _grid.GetCoord(pos);
        (int, int, int) endPosition = 
            _grid.GetCoord(targetPosition);

        List<GridNode> gridNodePath = _pathfinding.FindPath(
            startPosition.Item1,
            startPosition.Item2,
            startPosition.Item3,
            endPosition.Item1,
            endPosition.Item2,
            endPosition.Item3);

        if (gridNodePath == null) {
            Debug.Log("No path found!");
            return;
        }

        List<Vector3> path = new List<Vector3>();
        gridNodePath.RemoveAt(0);
        foreach (GridNode gridNode in gridNodePath) {
            path.Add(_grid.GetWorld(gridNode.x, gridNode.y, gridNode.z));
        }

        agentController.RequestPath(path);

    }

}
