using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovingJumpingState : AgentState {

    #region State Variables

    private AgentMovingState _superState;
    private bool _jumped;

    #endregion

    #region Constructor

    // Constructor
    public AgentMovingJumpingState(Agent _stateMachine, 
        AgentStateFactory _stateFactory) : 
        base (_stateMachine, _stateFactory) {}
    
    #endregion

    #region State Functions

    public override void EnterState() {

        // Set super state
        _superState = (AgentMovingState) superState;

        // Jump
        Vector3 dir = (new Vector3(_superState.target.x, 0,
            _superState.target.z) - ctx.transform.position)
            .normalized;
        ctx.rigidBody.AddForce(
            new Vector3(dir.x, 1.75f, dir.z),
            ForceMode.Impulse
        );

    }
    public override void UpdateState() {    }
    public override void CheckSwitchState() {
        
        // Switch to falling state
        if (!ctx.grounded && ctx.rigidBody.velocity.y <= 0) {
            SwitchState(factory.MovingFalling());
        }
    }
    public override void FixedUpdateState() {}
    public override void InitializeSubState() {}
    public override void ExitState() {}

    #endregion
    
}
