using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    #region Show In Inspector

    [SerializeField] Rigidbody2D _playerRb;

    #endregion

    #region Variables Globales

    private int _directionXId = Animator.StringToHash("DirectionX");
    private int _directionYId = Animator.StringToHash("DirectionY");
    private int _isIdleId = Animator.StringToHash("isIdle");
    private int _isRunningId = Animator.StringToHash("isRunning");
    private int _isJumpingId = Animator.StringToHash("isJumping");
    private int _isFallingId = Animator.StringToHash("isFalling");

    private Animator _playerAnimator;

    #endregion

    #region Unity LifeCycle
    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        _playerAnimator.SetFloat(_directionXId, _playerRb.velocity.x);
        _playerAnimator.SetFloat(_directionYId, _playerRb.velocity.y);
    }
    #endregion

    #region Animation States

    #region Idle Animation

    public void EnterIdleAnimation()
    {
        _playerAnimator.SetBool(_isIdleId, true);
    }

    public void ExitIdleAnimation()
    {
        _playerAnimator.SetBool(_isIdleId, false);
    }

    #endregion

    #region Run Animation

    public void EnterRunAnimation()
    {
        _playerAnimator.SetBool(_isRunningId, true);
    }

    public void ExitRunAnimation()
    {
        _playerAnimator.SetBool(_isRunningId, false);
    }

    #endregion

    #region Jump Animation

    public void EnterJumpUpAnimation()
    {
        _playerAnimator.SetBool(_isJumpingId, true);
    }

    public void ExitJumpUpAnimation()
    {
        _playerAnimator.SetBool(_isJumpingId, false);
    }

    #endregion

    #region Fall Animation

    public void EnterFallAnimation()
    {
        _playerAnimator.SetBool(_isFallingId, true);
    }

    public void ExitFallAnimation()
    {
        _playerAnimator.SetBool(_isFallingId, false);
    }

    #endregion

    #endregion
}
