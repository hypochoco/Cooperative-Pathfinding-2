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

        // Grounded sub state
        ctx.StartCoroutine(InitialiseGroundedSubState());

    }
    public override void UpdateState() {}
    public override void CheckSwitchState() {}
    public override void FixedUpdateState() {}
    public override void InitializeSubState() {
        SetSubState(factory.MovingGrounded());
        subState.EnterState();
    }
    public override void ExitState() {}

    #endregion

    #region Moving state functions

    // Wait until grounded before initilazing substate
    private IEnumerator InitialiseGroundedSubState() {
        while (!ctx.grounded) {
            yield return null;
        }
        InitializeSubState();
    }

    #endregion
    
}
