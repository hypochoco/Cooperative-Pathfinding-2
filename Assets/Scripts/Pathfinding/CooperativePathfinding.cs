using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// turn this into an interface and whatever... 
public class CooperativePathfinding {
    
    private PathfindingComponent _pathfindingComponent;
    private ReservationTable _reservationTable;
    private List<CooperativeAgent> _cooperativeAgents;

    // Getters and setters
    public bool goalsReached {
        get {
            foreach (CooperativeAgent cooperativeAgent in _cooperativeAgents) {
                if (!cooperativeAgent.goalReached) return false;
            }
            return true;
        }
    }

    
    // Constructor
    public CooperativePathfinding(PathfindingComponent pathfindingComponent) {
        _pathfindingComponent = pathfindingComponent;
        _reservationTable = new ReservationTable();
        _cooperativeAgents = new List<CooperativeAgent>();
    }

    // Main cooperative pathfinding loop
    public void Tick() {

        // Check if goals have been reached
        if (goalsReached) {
            return;
        }

        // Plan initial paths for each agent
        // store these paths in the reservation table
        foreach (CooperativeAgent cooperativeAgent in _cooperativeAgents) {
            if (cooperativeAgent.goal == null) continue;
            List<Vector3> path = 
                _pathfindingComponent
                .FindPath(cooperativeAgent.position, cooperativeAgent.goal);
            cooperativeAgent.path = path;
            _reservationTable.Add(path);
        }

        // Find an resolve the first conflict
        


    }
    

}