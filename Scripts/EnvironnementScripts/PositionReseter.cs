using UnityEngine;
using System.Collections;

[SelectionBase]
public class PositionReseter : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Color _baseColor;
    [SerializeField] float _respawnDuration = 0.5f;
    [SerializeField] CheckForPlayer _checkForPlayer;

    private Vector3 _startPosition;
    private float _rbStartMass;
    private float _rbStartGravity;
    private bool _canReset;

    private void Start()
    {
        _startPosition = transform.position;
        _rbStartMass = _rb.mass;
        _rbStartGravity = _rb.gravityScale;
        _canReset = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathEdge"))
        {
            _canReset = true;
        }
    }

    private void Update()
    {
        if (_canReset && !_checkForPlayer.PlayerIsHere())
        {
            PositionReset();
        }
    }

    private void PositionReset()
    {
        Debug.Log("Resetting");
        _rb.velocity = Vector2.zero;
        _rb.mass = _rbStartMass;
        _rb.gravityScale = _rbStartGravity;
        _spriteRenderer.color = _baseColor;
        transform.rotation = Quaternion.identity;
        transform.position = _startPosition;
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        _canReset = false;
        //gameObject.SetActive(true);
        //StartCoroutine(PaintableRespawn());
    }

    //IEnumerator PaintableRespawn()
    //{
    //    yield return new WaitForFixedUpdate();
    //    gameObject.SetActive(true);
    //}



}
