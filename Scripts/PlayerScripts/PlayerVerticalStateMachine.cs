using UnityEngine;
 public enum VerticalMovement
{
    GROUNDED,
    JUMPUP,
    FALL
}
public class PlayerVerticalStateMachine : MonoBehaviour
{
   
    #region Show In Inspector
    
    [SerializeField] PlayerAnimatorController _playerAnimatorController;
    [SerializeField] Rigidbody2D _playerRb;

    #endregion

    #region Public Properties

    public VerticalMovement VerticalCurrentState { get; private set; }

    #endregion


    private void Update()
    {
        OnStateUpdate(VerticalCurrentState);
    }
    
    #region State Machine
    
    private void OnStateEnter(VerticalMovement state)
    {
        switch (state)
        {
            case VerticalMovement.GROUNDED:
                DoGroundedEnter();
                break;
    
            case VerticalMovement.JUMPUP:
                DoJumpUpEnter();
                break;
    
            case VerticalMovement.FALL:
                DoFallEnter();
                break;
        }
    }
    
    private void OnStateExit(VerticalMovement state)
    {
        switch (state)
        {
            case VerticalMovement.GROUNDED:
                DoGroundedExit();
                break;
    
            case VerticalMovement.JUMPUP:
                DoJumpUpExit();
                break;
    
            case VerticalMovement.FALL:
                DoFallExit();
                break;
        }
    }
    
    private void OnStateUpdate(VerticalMovement state)
    {
        switch (state)
        {
            case VerticalMovement.GROUNDED:
                DoGroundedUpdate();
                break;
    
            case VerticalMovement.JUMPUP:
                DoJumpUpUpdate();
                break;
    
            case VerticalMovement.FALL:
                DoFallUpdate();
                break;
        }
    }
    
    private void TransitionToState(VerticalMovement fromState, VerticalMovement toState)
    {
        OnStateExit(fromState);
        VerticalCurrentState = toState;
        OnStateEnter(toState);
    }
    
    
    #endregion
    
    #region Grounded State
    
    private void DoGroundedEnter()
    {
        _playerAnimatorController.EnterIdleAnimation();
    }
    
    private void DoGroundedExit()
    {
        _playerAnimatorController.ExitIdleAnimation();
    }
    
    private void DoGroundedUpdate()
    {
        if(_playerRb.velocity.y > 0.1f)
        {
            TransitionToState(VerticalCurrentState, VerticalMovement.JUMPUP);
        }
    }
    
    #endregion
    
    #region Jump Up State
    
    private void DoJumpUpEnter()
    {
        _playerAnimatorController.EnterJumpUpAnimation();
    }
    
    private void DoJumpUpExit()
    {
        _playerAnimatorController.ExitJumpUpAnimation();
    }
    
    private void DoJumpUpUpdate()
    {
        if (_playerRb.velocity.y < 0.1f)
        {
            TransitionToState(VerticalCurrentState, VerticalMovement.FALL);
        }
    }
    
    #endregion
    
    #region Fall State
    
    private void DoFallEnter()
    {
        _playerAnimatorController.EnterFallAnimation();
    }
    
    private void DoFallExit()
    {
        _playerAnimatorController.ExitFallAnimation();
    }
    
    private void DoFallUpdate()
    {
        if (_playerRb.velocity.y > -0.1f && _playerRb.velocity.y < 0.1f)
        {
            TransitionToState(VerticalCurrentState, VerticalMovement.GROUNDED);
        }
    }
    
    #endregion
    
}
