using UnityEngine;

public class BrushAnimatorController : MonoBehaviour
{
    #region Variables Globales

    private int _isBrushIdleId = Animator.StringToHash("isIdle");
    private int _isPaintingId = Animator.StringToHash("isPainting");
    private int _isTriggerId = Animator.StringToHash("PaintTrigger");

    private Animator _brushAnimator;

    #endregion

    #region Unity LifeCycle
    private void Awake()
    {
        _brushAnimator = GetComponent<Animator>();
    }

    #endregion

    #region Brush Animation States

    #region Idle Animation

    public void EnterBrushIdleAnimation()
    {
        _brushAnimator.SetBool(_isBrushIdleId, true);
    }

    public void ExitBrushIdleAnimation()
    {
        _brushAnimator.SetBool(_isBrushIdleId, false);
    }

    #endregion

    #region Paint Animation

    public void EnterPaintAnimation()
    {
        _brushAnimator.SetBool(_isPaintingId, true);
    }

    public void ExitPaintAnimation()
    {
        _brushAnimator.SetBool(_isPaintingId, false);
    }

    #endregion

    public void TriggerPaintAnimation()
    {
        _brushAnimator.SetTrigger(_isTriggerId);
    }

    #endregion
}
