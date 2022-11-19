using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentIdleState : AgentState {

    #region State Variables

    #endregion

    #region Constructor

    // Constructor
    public AgentIdleState(Agent _stateMachine, 
        AgentStateFactory _stateFactory) : 
        base (_stateMachine, _stateFactory) {
        
        rootState = true;
    }

    #endregion

    #region State Functions

    public override void EnterState() {

        // Change agent color to white!
        ctx.material.color = Color.white;        

    }
    public override void UpdateState() {}
    public override void CheckSwitchState() {}
    public override void FixedUpdateState() {}
    public override void InitializeSubState() {}
    public override void ExitState() {}

    #endregion

}
