using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooperativeAgent : MonoBehaviour {
    
    [SerializeField] private Vector3 _goal;
    [SerializeField] private List<Vector3> _path;
    [SerializeField] private AgentController _agentController;

    public Vector3 goal {
        get {return _goal;}
        set {_goal = value;}
    }
    public List<Vector3> path {
        get {return _path;}
        set {_path = value;}
    }
    public Vector3 position {
        get {return _agentController.agent.transform.position;}
    }

    // Getters and setters
    public bool goalReached {
        get {
            if (_goal == null) return true;

            return (_agentController.agent.transform.position - goal)
                .sqrMagnitude < 0.125f;
        }
    }

}
