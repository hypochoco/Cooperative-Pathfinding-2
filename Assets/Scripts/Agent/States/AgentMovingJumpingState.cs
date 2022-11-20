using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovingJumpingState : AgentState {

    #region State Variables

    private AgentMovingState _superState;
    private bool _jumped;
    private Vector3 _dir;
    private float _targetVelocity;

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
        _targetVelocity = 10f;
        _dir = (_superState.target - ctx.transform.position)
            .normalized;
        ctx.rigidBody.AddForce(
            new Vector3(0, _dir.y > 0.2? 2.5f : 1.75f, 0),
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
        ctx.rigidBody.velocity += 
            new Vector3(_dir.x, 0, _dir.z) * 5f * Time.deltaTime;
    }
    public override void InitializeSubState() {}
    public override void ExitState() {}

    #endregion
    
}
