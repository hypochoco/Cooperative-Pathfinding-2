using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This will contain a space-time point

public class ReservationTable {
    
    // space time points
    private Dictionary<Vector3, int> table;

    // Constructor
    public ReservationTable() {
        table = new Dictionary<Vector3, int>();
    }

    // Reserve a path
    public void Add(List<Vector3> path) {
        for (int i = 0; i < path.Count; i++) {
            table.Add(path[0], i);
        }
    }

    // Clear the table
    public void Clear() {
        table = new Dictionary<Vector3, int>();
    }

}
