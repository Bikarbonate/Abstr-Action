using UnityEngine;

public enum BrushState
{
    IDLE,
    PAINT
}

public class BrushStateMachine : MonoBehaviour
{
    #region Show In Inspector

    [SerializeField] BrushAnimatorController _brushAnimatorController;
    [SerializeField] BrushController _brushController;
    [SerializeField] private PlayerSFXManager _playerSFXManager;

    #endregion

    private BrushState _brushCurrentState;

    private void Update()
    {
        OnStateUpdate(_brushCurrentState);
    }

    #region State Machine

    private void OnStateEnter(BrushState state)
    {
        switch (state)
        {
            case BrushState.IDLE:
                DoBrushIdleEnter();
                break;

            case BrushState.PAINT:
                DoPaintEnter();
                break;
        }
    }

    private void OnStateExit(BrushState state)
    {
        switch (state)
        {
            case BrushState.IDLE:
                DoBrushIdleExit();
                break;

            case BrushState.PAINT:
                DoPaintExit();
                break;
        }
    }

    private void OnStateUpdate(BrushState state)
    {
        switch (state)
        {
            case BrushState.IDLE:
                DoBrushIdleUpdate();
                break;

            case BrushState.PAINT:
                DoPaintUpdate();
                break;
        }
    }

    private void TransitionToState(BrushState fromState, BrushState toState)
    {
        OnStateExit(fromState);
        _brushCurrentState = toState;
        OnStateEnter(toState);
    }


    #endregion

    #region Brush Idle State

    private void DoBrushIdleEnter()
    {
        _brushAnimatorController.EnterBrushIdleAnimation();
    }

    private void DoBrushIdleExit()
    {
        _brushAnimatorController.ExitBrushIdleAnimation();
    }

    private void DoBrushIdleUpdate()
    {
        if(_brushController.IsPainting)
        {
            TransitionToState(_brushCurrentState, BrushState.PAINT);
        }
    }

    #endregion

    #region Paint State

    private void DoPaintEnter()
    {
        //_brushAnimatorController.EnterPaintAnimation();
        _brushAnimatorController.TriggerPaintAnimation();
        _playerSFXManager.PlaySwooshSFX();
    }

    private void DoPaintExit()
    {
        //_brushAnimatorController.ExitPaintAnimation();
    }

    private void DoPaintUpdate()
    {
        if (!_brushController.IsPainting)
        {
            TransitionToState(_brushCurrentState, BrushState.IDLE);
        }
    }

    #endregion
}
