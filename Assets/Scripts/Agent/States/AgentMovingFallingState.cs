using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovingFallingState : AgentState {

    #region State Variables

    #endregion

    #region Constructor

    // Constructor
    public AgentMovingFallingState(Agent _stateMachine, 
        AgentStateFactory _stateFactory) : 
        base (_stateMachine, _stateFactory) {}
    
    #endregion

    #region State Functions

    public override void EnterState() {}
    public override void UpdateState() {}
    public override void CheckSwitchState() {
        if (ctx.grounded) {
            SwitchState(factory.MovingGrounded());
        }
    }
    public override void FixedUpdateState() {}
    public override void InitializeSubState() {}
    public override void ExitState() {}

    #endregion
    
}