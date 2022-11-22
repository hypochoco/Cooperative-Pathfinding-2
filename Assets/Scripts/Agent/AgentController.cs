using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour {
    
    // Variables
    [SerializeField] private Agent _agent;
    private LinePath _linePath;
    [SerializeField] private int _pathIndex;
    private float _turnDst;

    // Getters and setters
    public Agent agent {
        get {return _agent;}
    }

    // Initialize variables
    private void Start() {
        _turnDst = 0.125f;
    }

    // Unity functions
    private void Update() {

        // Ensure agent and path
        if (_agent == null || _linePath == null) {
            return;
        }
        
        // TODO: Ensure that the agent stays at the thing for some
        // fixed amount of time!!!

        // Go through the path
        Vector2 pos2d = 
            new Vector2(_agent.transform.position.x,_agent.transform.position.z);
        if (_linePath.TurnBoundaries[_pathIndex].HasCrossedLine(pos2d)) {
            while (_linePath.TurnBoundaries[_pathIndex].HasCrossedLine(pos2d)) {
                if (_pathIndex == _linePath.FinishLineIndex) {
                    _linePath = null;
                    _agent.Idle();
                    return;
                }
                _pathIndex++;
            }
            _agent.Move(_linePath.LookPoints[_pathIndex]);
        }
    }

    // AgentController functions
    public void RequestPath(List<Vector3> waypoints) {

        if (waypoints.Count <= 0 ) {
            return;
        }

        _pathIndex = 0;
        _linePath = new LinePath(waypoints, 
            _agent.transform.position, _turnDst);
        _agent.Move(_linePath.LookPoints[_pathIndex]);
        
    }

    // Testing Purposes
    private void OnDrawGizmos() {
        if (_linePath != null) {
            _linePath.DrawWithGizmos();
        }
    }

}
