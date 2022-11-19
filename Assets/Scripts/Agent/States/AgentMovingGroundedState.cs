using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovingGroundedState : AgentState {

    #region State Variables

    private AgentMovingState _superState;

    #endregion

    #region Constructor

    // Constructor
    public AgentMovingGroundedState(Agent _stateMachine, 
        AgentStateFactory _stateFactory) : 
        base (_stateMachine, _stateFactory) {}
    
    #endregion

    #region State Functions

    public override void EnterState() {

        // Set super state
        _superState = (AgentMovingState) superState;

        // Look at the target position
        Vector3 dir = _superState.target - ctx.transform.position;
        ctx.transform.rotation = 
            Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));

        // Enter jump state
        SwitchState(factory.MovingJumping());

    }
    public override void UpdateState() {}
    public override void CheckSwitchState() {}
    public override void FixedUpdateState() {}
    public override void InitializeSubState() {}
    public override void ExitState() {}

    #endregion
    
}
