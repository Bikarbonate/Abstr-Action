using UnityEngine;

public enum HorizontalMovement
{
    IDLE,
    RUN
}

public class PlayerHorizontalStateMachine : MonoBehaviour
{
    #region Show In Inspector

    [SerializeField] PlayerAnimatorController _playerAnimatorController;
    [SerializeField] Rigidbody2D _playerRb;
    [SerializeField] PlayerVerticalStateMachine _verticalStateMachine;

    #endregion

    private HorizontalMovement _horizontalCurrentState;

    private void Update()
    {
        OnStateUpdate(_horizontalCurrentState);
    }

    #region State Machine

    private void OnStateEnter(HorizontalMovement state)
    {
        switch(state)
        {
            case HorizontalMovement.IDLE:
                DoIdleEnter();
                break;

            case HorizontalMovement.RUN:
                DoRunEnter();
                break;
        }            
    }

    private void OnStateExit(HorizontalMovement state)
    {
        switch(state)
        {
            case HorizontalMovement.IDLE:
                DoIdleExit();
                break;

            case HorizontalMovement.RUN:
                DoRunExit();
                break;
        }
    }

    private void OnStateUpdate(HorizontalMovement state)
    {
        switch(state)
        {
            case HorizontalMovement.IDLE:
                DoIdleUpdate();
                break;

            case HorizontalMovement.RUN:
                DoRunUpdate();
                break;
        }
    }

    private void TransitionToState(HorizontalMovement fromState, HorizontalMovement toState)
    {
        OnStateExit(fromState);
        _horizontalCurrentState = toState;
        OnStateEnter(toState);
    }
        

    #endregion

    #region Idle State

    private void DoIdleEnter()
    {
        _playerAnimatorController.EnterIdleAnimation();
    }

    private void DoIdleExit()
    {
        _playerAnimatorController.ExitIdleAnimation();
    }

    private void DoIdleUpdate()
    {
        if (_playerRb.velocity.x > 0 || _playerRb.velocity.x < 0)
        {
            TransitionToState(_horizontalCurrentState, HorizontalMovement.RUN);
        }
    }

    #endregion

    #region Run State

    private void DoRunEnter()
    {
        _playerAnimatorController.EnterRunAnimation();
    }

    private void DoRunExit()
    {
        _playerAnimatorController.ExitIdleAnimation();
    }

    private void DoRunUpdate()
    {
        if (_playerRb.velocity.x > -0.1f && _playerRb.velocity.x < 0.1f)
        {
            TransitionToState(_horizontalCurrentState, HorizontalMovement.IDLE);
        }

        if (_verticalStateMachine.VerticalCurrentState == VerticalMovement.GROUNDED)
        {
            TransitionToState(_horizontalCurrentState, HorizontalMovement.IDLE);
        }
    }

    #endregion
}
