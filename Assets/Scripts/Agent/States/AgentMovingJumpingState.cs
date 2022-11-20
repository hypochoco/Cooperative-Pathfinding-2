using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovingJumpingState : AgentState {

    #region State Variables

    private AgentMovingState _superState;
    private Vector3 _dir;
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
        _dir = (_superState.target - ctx.transform.position);
        ctx.rigidBody.AddForce(
            new Vector3(0, _dir.y > 0.1? 2.75f : 1.75f, 0),
            ForceMode.Impulse
        );

    }
    public override void UpdateState() {}
    public override void CheckSwitchState() {
        
        // Switch to falling state
        if (!ctx.grounded && ctx.rigidBody.velocity.y <= 0) {
            SwitchState(factory.MovingFalling());
        }
    }
    public override void FixedUpdateState() {
        ctx.rigidBody.velocity += 5f * Time.deltaTime * 
            new Vector3(_dir.x, 0, _dir.z).normalized;
    }
    public override void InitializeSubState() {}
    public override void ExitState() {}

    #endregion
    
}
