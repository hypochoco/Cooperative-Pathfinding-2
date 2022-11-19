using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    
    private Camera _mainCam;
    private GameObject _selectedObject;

    private void Start() {
        _mainCam = Camera.main;
    }

    private void Update() {

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit[] hits = CastRay();

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

            if (_selectedObject != null && 
                _selectedObject.TryGetComponent<AgentController>(out var agentController)) {
                
                agentController.RequestPath(new List<Vector3>() {hits[0].point});
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
