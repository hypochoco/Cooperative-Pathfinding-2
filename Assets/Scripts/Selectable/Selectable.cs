using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {
    
    // Variables
    [SerializeField] private GameObject _indicator;
    [SerializeField] private bool _selected;

    // Getters and setters
    public bool selected {
        get {return _selected;}
    }

    // Toggle Selection
    public void Toggle() {
        _selected = !_selected;
        _indicator.SetActive(_selected);
    }
    public void Toggle(bool select) {
        _selected = select;
        _indicator.SetActive(_selected);
    }

}
