using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    
    // fix this to be better and toggle correctly and stuff... 
    // then the next steps is to go for cooperative pathfinding

    // finally its dealing with larger cubes and variable speed cubes...
    // also deal with a player dicking around adn stuff.. 

    // get a better input system for multiple selections
    // 

    private Camera _mainCam;
    [SerializeField] private GameObject _selectedObject;
    [SerializeField] private PathfindingComponent _pathfindingComponent;

    private void Start() {
        _mainCam = Camera.main;
    }

    private void Update() {

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit[] hits = CastRay();

            // move the thing
            // toggle onto another thing... 

            // foreach (RaycastHit hit in hits) {
            //     GameObject hitObject = hit.collider.gameObject;
            //     if (hitObject.TryGetComponent<Selectable>(out var selectable)) {
                    
            //         if (_selectedObject != null) {
            //             _selectedObject.GetComponent<Selectable>().Toggle();
            //         }

            //         selectable.Toggle();

            //         if (selectable.selected) {
            //             _selectedObject = hitObject;
            //         } else {
            //             _selectedObject = null;
            //         }
                    
            //     }
            // }


            if (_selectedObject != null && 
                _selectedObject.TryGetComponent<AgentController>(out var agentController)) {
                
                _pathfindingComponent.TestPathfinding(agentController, hits[0].point);
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

}
