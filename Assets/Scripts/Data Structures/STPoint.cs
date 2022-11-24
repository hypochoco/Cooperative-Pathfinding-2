using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STPoint<T> {

    // Contains a vector3 for the position...
    // Contains a way to hold the time... 

    private int _time;
    private Vector3 _position;
    private List<T> _objects;

    // Getters and setters
    public int time {
        get {return _time;}
    }
    public Vector3 position {
        get {return _position;}
    }
    public List<T> objects {
        get {return _objects;}
    }

    public STPoint<T> Add(T item) {
        _objects.Add(item);
        return this;
    }

    // Constructor
    public STPoint(int time, Vector3 position) {
        _time = time;
        _position = position;
        _objects = new List<T>();
    }

}
