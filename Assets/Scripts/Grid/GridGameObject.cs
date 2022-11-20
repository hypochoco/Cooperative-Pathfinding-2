using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Physics.CheckSphere...

// RGridConstructor
public class GridGameObject : MonoBehaviour {
    
    #region Grid Constructor Variables
    
    // Grid Constructor Variables
    private Grid<GridNode> _grid; 
    [SerializeField] private bool _debug;

    // Getters and setters
    public Grid<GridNode> grid {
        get {return _grid;}
    }

    #endregion

    #region Unity Functions

    private void Awake() {
        _grid = Preset0();
    }

    #endregion

    #region Grid Presets

    public Grid<GridNode> Preset0() {
        
        // intial variables
        float cellSize = 0.5f;
        float cellSizeY = 0.25f;

        // create a grid
        Grid<GridNode> grid = new Grid<GridNode>(cellSize, cellSizeY);

        // Main grid
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                grid.Add(i, 0, j, new GridNode(i, 0, j));
            }
        }

        // Manual Grid Additions
        grid.Add(10, 1, 5, new GridNode(10, 1, 5));
        grid.Add(11, 2, 5, new GridNode(11, 2, 5));
        grid.Add(12, 3, 5, new GridNode(12, 3, 5));

        // Secondary grid
        for (int i = 13; i < 22; i++) {
            for (int j = 1; j < 10; j++) {
                grid.Add(i, 3, j, new GridNode(i, 3, j));
            }
        }

        // Return Preset
        return grid;

    }

    #endregion

    #region Debug

    public void OnDrawGizmos() {

        // Debug
        if (!_debug)
            return;

        // Draw grid gizmos
        if (_grid == null || _grid.Array == null)
            return;
        float s = 0.25f;
        foreach (GridNode node in _grid.Array) {
            if (node == null)
                continue;
            Gizmos.color = (node.Walkable)? 
                new Color(1, 1, 1, 0.25f) : new Color(0, 0, 0, 0.25f);
            Vector3 pos = _grid.GetWorld(node.x, node.y, node.z);
            Gizmos.DrawCube(pos, new Vector3(s, s, s));
        }
    }

    #endregion

}

