using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(SpriteRenderer))]

public class PropColorToPhysics : MonoBehaviour
{
    #region Show In Inspector

    [Header("Component Reference")]
    [SerializeField] private BrushController _brushController;

    [Header("Physics")]
    [SerializeField] private float _redMassMultiplier = 0.5f;
    [SerializeField] private float _redGravityScaleMultiplier = -1;
    [SerializeField] private float _blueGravityScaleMultiplier = 5;
    [SerializeField] private float _blueMassMultiplier = 4;

    #endregion

    #region Variables Globales

    private Rigidbody2D _propRb;
    private SpriteRenderer _propSpriteRenderer;

    #endregion

    private void Awake()
    {
        _propRb = GetComponent<Rigidbody2D>();
        _propSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ApplyColorPhysicsChange();
    }

    public void ApplyColorPhysicsChange()
    {
        if (_propSpriteRenderer.color == _brushController.RedPaint)
        {
            Debug.Log("Color : red");
            _propRb.gravityScale = _redGravityScaleMultiplier;
            _propRb.mass = _redMassMultiplier;
            _propRb.constraints = RigidbodyConstraints2D.None;
        }

        if(_propSpriteRenderer.color == _brushController.BluePaint)
        {
            Debug.Log("Color : blue");
            _propRb.gravityScale = _blueGravityScaleMultiplier;
            _propRb.mass = _blueMassMultiplier;
            _propRb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
