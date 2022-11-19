using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    
    private Camera _mainCam; 
    [SerializeField] private Agent _agent;

    private void Start() {
        _mainCam = Camera.main;
    }

    private void Update() {

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit[] hits = CastRay();
            _agent.RequestMove(hits[0].point);
        }

    }

    private RaycastHit[] CastRay() {
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray.origin, 
        ray.direction, 2000f);
        return hits;
    }


}
