using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This will contain a space-time point

public class ReservationTable {
    
    // space time points
    private Dictionary<int, Dictionary<Vector3, STPoint<CooperativeAgent>>> table;
    // collision
    private int _firstCollision;

    // Constructor
    public ReservationTable() {
        table = new Dictionary<int, Dictionary<Vector3, STPoint<CooperativeAgent>>>();
    }

    // Reserve a path
    public void Add(int startingIndex, CooperativeAgent agent, List<Vector3> path) {
        for (int i = 0; i< path.Count; i++) {
            if (table[startingIndex + i] != null) {
                Dictionary<Vector3, STPoint<CooperativeAgent>> point0 = 
                    table[startingIndex + i];

                STPoint<CooperativeAgent> point1 = point0[path[i]] == null?
                    new STPoint<CooperativeAgent>
                        (startingIndex + i, path[i]) : point0[path[i]];
                point1.Add(agent);                
            } else {
                Dictionary<Vector3, STPoint<CooperativeAgent>> point0 = 
                    new Dictionary<Vector3, STPoint<CooperativeAgent>>();
                point0.Add(path[i], new STPoint<CooperativeAgent>
                    (startingIndex + i, path[i]).Add(agent));
                table[startingIndex + i] = 
                    new Dictionary<Vector3, STPoint<CooperativeAgent>>();
            }
            
        }
    
    }

    // Clear the table
    public void Clear() {
        table = new Dictionary<int, Dictionary<Vector3, STPoint<CooperativeAgent>>>();
    }

}
