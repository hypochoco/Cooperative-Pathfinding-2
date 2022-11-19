using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    
    private Camera _mainCam; 
    [SerializeField] private AgentController _agentController;

    private void Start() {
        _mainCam = Camera.main;
    }

    private void Update() {

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit[] hits = CastRay();
            _agentController.RequestPath(new List<Vector3>() {hits[0].point});
        }

    }

    private RaycastHit[] CastRay() {
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray.origin, 
        ray.direction, 2000f);
        return hits;
    }


}
