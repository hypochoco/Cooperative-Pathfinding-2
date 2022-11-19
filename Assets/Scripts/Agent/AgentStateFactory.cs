using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region State Skeleton

// public class AgentStateEMPTY : AgentState {

//     #region State Variables

//     #endregion

//     #region Constructor

//     // Constructor
//     public AgentStateEMPTY(Agent _stateMachine, 
//         AgentStateFactory _stateFactory) : 
//         base (_stateMachine, _stateFactory) {}
    
//     #endregion

//     #region State Functions

//     public override void EnterState() {}
//     public override void UpdateState() {}
//     public override void CheckSwitchState() {}
//     public override void FixedUpdateState() {}
//     public override void InitializeSubState() {}
//     public override void ExitState() {}

//     #endregion
    
// }

#endregion

public class AgentStateFactory {

    // Variables
    private Agent _stateMachine;

    // Constructor
    public AgentStateFactory(Agent stateMachine) {
        _stateMachine = stateMachine;
    }

    // State Constructors
    public AgentIdleState Idle() {
        return new AgentIdleState(_stateMachine, this);
    }
    public AgentMovingState Moving(Vector3 target) {
        return new AgentMovingState(_stateMachine, this, target);
    }
    public AgentMovingGroundedState MovingGrounded() {
        return new AgentMovingGroundedState(_stateMachine, this);
    }
    public AgentMovingJumpingState MovingJumping() {
        return new AgentMovingJumpingState(_stateMachine, this);
    }
    public AgentMovingFallingState MovingFalling() {
        return new AgentMovingFallingState(_stateMachine, this);
    }

}
