using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovingState: AgentState {

    #region State Variables

    private Vector3 _target;

    public Vector3 target {
        get {return _target;}
    }

    #endregion

    #region Constructor

    // Constructor
    public AgentMovingState(Agent _stateMachine, 
        AgentStateFactory _stateFactory, Vector3 target) : 
        base (_stateMachine, _stateFactory) {
        rootState = true;
        _target = target;
    }
    
    #endregion

    #region State Functions

    public override void EnterState() {

        // Testing purposes
        ctx.material.color = Color.red;

        // Start moving sub-states
        InitializeSubState();
    }
    public override void UpdateState() {}
    public override void CheckSwitchState() {
        if ((ctx.transform.position - target).sqrMagnitude < 0.125f) {
            SwitchState(factory.Idle());
        }
    }
    public override void FixedUpdateState() {}
    public override void InitializeSubState() {
        SetSubState(factory.MovingGrounded());
        subState.EnterState();
    }
    public override void ExitState() {}

    #endregion
    
}
