using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    
    // fix this to be better and toggle correctly and stuff... 

    private Camera _mainCam;
    [SerializeField] private GameObject _selectedObject;
    [SerializeField] private GameObject _gridGameObject;
    private Grid<GridNode> _grid;

    private void Start() {
        _mainCam = Camera.main;
    }

    private void Update() {

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit[] hits = CastRay();

            if (_selectedObject != null && 
                _selectedObject.TryGetComponent<AgentController>(out var agentController)) {
                
                TestPathfinding(agentController, hits[0].point);
                // agentController.RequestPath(new List<Vector3>() {hits[0].point});

            }

            foreach (RaycastHit hit in hits) {
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.TryGetComponent<Selectable>(out var selectable)) {
                    selectable.Toggle();
                    if (selectable.selected) {
                        _selectedObject = hitObject;
                    } else {
                        _selectedObject = null;
                    }
                }
            }

        }

    }

    private RaycastHit[] CastRay() {
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray.origin, 
        ray.direction, 2000f);
        return hits;
    }

    // pathfinding test
    private void TestPathfinding(
        AgentController agentController, Vector3 targetPosition) {

        _grid = _gridGameObject.GetComponent<GridGameObject>().grid;
        Pathfinding pathfinding = new Pathfinding(_grid);
        Vector3 pos = agentController.agent.transform.position
            + 0.125f * Vector3.down;
        (int, int, int) startPosition = 
            _grid.GetCoord(pos);
        (int, int, int) endPosition = 
            _grid.GetCoord(targetPosition);

        List<GridNode> gridNodePath = pathfinding.FindPath(
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
