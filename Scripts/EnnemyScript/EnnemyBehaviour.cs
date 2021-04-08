using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    #region Show In Inspector

    [SerializeField] Transform _ennemyTransform;
    [SerializeField] RaycastHit2D[] _hitBuffer = new RaycastHit2D[1];
    [SerializeField] Color _gizmosColor;
    [SerializeField] float _checkDistance;
    [SerializeField] LayerMask _whatIsPlayer;
    [SerializeField] float _ennemyMovementSpeed;
    [SerializeField] Transform _targetTransform;
    [SerializeField] Transform _startPosition;
    [SerializeField] HitBoxManager _playerHitBoxManager;

    #endregion

    #region Variables Globales

    #endregion

    #region Unity LifeCycle

    private void Update()
    {
        float step = _ennemyMovementSpeed * Time.deltaTime;
        if (CheckForPlayer())
        {
            Debug.Log("VU");
            _ennemyTransform.position = Vector2.MoveTowards(_ennemyTransform.position, _targetTransform.position, step);

            
        }

        if (_playerHitBoxManager.IsDead || !CheckForPlayer())
        {
            _ennemyTransform.position = Vector2.MoveTowards(_ennemyTransform.position, _startPosition.position, step);
        }
    }


    #endregion

    #region Private Methods

    private bool CheckForPlayer()
    {
        int playerIsHere = Physics2D.RaycastNonAlloc(_ennemyTransform.position, Vector2.left, _hitBuffer, _checkDistance, _whatIsPlayer);
        return playerIsHere > 0;
    }

    #endregion


    #region DrawGizmos

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawRay(_ennemyTransform.position, Vector2.left * _checkDistance);
    }

    #endregion
}
