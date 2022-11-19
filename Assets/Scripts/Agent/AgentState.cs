using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AgentState {

    #region State variables

    // State variables
    private bool _rootState;
    private Agent _stateMachine;
    private AgentState _currentSuperState;
    private AgentState _currentSubState;
    private AgentStateFactory _stateFactory;

    // Getters and setters
    public Agent ctx {
        get {return _stateMachine;}
    }
    public bool rootState {
        get {return _rootState;}
        set {_rootState = value;}
    }
    public AgentState superState {
        get {return _currentSuperState;}
    }
    public AgentState subState {
        get {return _currentSubState;}
    }
    public AgentStateFactory factory {
        get {return _stateFactory;}
    }

    #endregion

    #region Constructor

    // Constructor
    public AgentState(Agent stateMachine, AgentStateFactory stateFactory) {
        _stateMachine = stateMachine;
        _stateFactory = stateFactory;
    }

    #endregion

    #region State functions

    // Basic state functions
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void CheckSwitchState();
    public abstract void FixedUpdateState();
    public abstract void InitializeSubState();
    public abstract void ExitState();

    // Hierarchical state functions
    public void UpdateStates() {
        UpdateState();
        if (_currentSubState != null)
            _currentSubState.UpdateStates();
    }
    public void CheckSwitchStates() {
        CheckSwitchState();
        if (_currentSubState != null)
            _currentSubState.CheckSwitchStates();
    }
    public void FixedUpdateStates() {
        FixedUpdateState();
        if (_currentSubState != null) 
            _currentSubState.FixedUpdateStates();
    }
    public void ExistStates() {
        ExitState();
        if (_currentSubState != null)
            _currentSubState.ExistStates();
    }
    public void SwitchState(AgentState newState) {
        ExistStates();
        if (_rootState) {
            _stateMachine.state = newState;
        } else if (_currentSuperState != null) {
            _currentSuperState.SetSubState(newState);
        }
        newState.EnterState();
    }
    public void SetSuperState(AgentState newSuperState) {
        _currentSuperState = newSuperState;
    }
    public void SetSubState(AgentState newSubState) {
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }
    
    #endregion

}
