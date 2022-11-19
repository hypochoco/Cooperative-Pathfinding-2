using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Agent
public class Agent : MonoBehaviour {
    
    #region Agent variables

    // Agent variables
    private float _distToGround;
    [SerializeField] private bool _grounded;
    [SerializeField] private Queue<Vector3> _targetQueue;

    // Agent reference variables
    [SerializeField] private Transform _transform;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Rigidbody _rigidBody;
    private Material _material;

    // State variables
    private AgentState _state;
    private AgentStateFactory _stateFactory;

    // Getters and setters
    public AgentState state {
        get {return _state;}
        // Warning: Use SwitchState instead!
        set {_state = value;}
    }
    public Material material {
        get {return _material;}
    }
    public bool grounded {
        get {return _grounded;}
    }
    public Rigidbody rigidBody {
        get {return _rigidBody;}
    }

    #endregion

    #region Unity functions

    // Initialize variables
    private void Start() {
        _distToGround = 0.13f;
        _grounded = false;
        _material = _renderer.material;
        _targetQueue = new Queue<Vector3>();
        _stateFactory = new AgentStateFactory(this);
        _state = _stateFactory.Idle();
        _state.EnterState();
    }

    private void Update() {

        // Go through the move queue... 
        if (_state is AgentIdleState && _targetQueue.Count > 0) {
            Move(_targetQueue.Dequeue());
        }

        // State Functions
        _state.UpdateStates();
        _state.CheckSwitchStates();
    }
    private void FixedUpdate() {
        _grounded = Grounded();
        _state.FixedUpdateStates();
    }

    #endregion

    #region Agent functions

    // Check for ground
    public bool Grounded() {

        // Cache values
        Vector3 pos = _transform.position;
        Vector2 perp2D = Vector2.
            Perpendicular(new Vector2(pos.x, pos.z));
        Vector3 perp = new Vector3(perp2D.x, 0, perp2D.y);

        // Check each corner for grounded
        return (
            Physics.Raycast(pos, Vector3.down, _distToGround) ||
            Physics.Raycast(pos + perp, Vector3.down, _distToGround) ||
            Physics.Raycast(pos - perp, Vector3.down, _distToGround) ||
            Physics.Raycast(-pos + perp, Vector3.down, _distToGround) ||
            Physics.Raycast(-pos - perp, Vector3.down, _distToGround)
        );
    }

    // Hop to a point
    public void Move(Vector3 target) {
        _state.SwitchState(_stateFactory.Moving(target));
    }

    // Request a move to a point
    public void RequestMove(Vector3 target) {
        _targetQueue.Enqueue(target);
    }

    #endregion

}
