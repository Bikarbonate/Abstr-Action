using UnityEngine;

public class PhysicsToEffects : MonoBehaviour
{
    [Header("CameraShake")]
    [SerializeField] CineMachineShake _cineMachineShake;
    [SerializeField] BrushController _brushController;
    [SerializeField] float _cameraShakeIntensity;
    [SerializeField] float _cameraShakeFrequency;
    [SerializeField] float _cameraShakeTime;

    [Header("Sounds")]
    [SerializeField] AudioSource _propAudioSource;
    [SerializeField] AudioClip _stumpAudioClip;
    

    private SpriteRenderer _propSpriteRenderer;
    private Rigidbody2D _propRb;

    private void Awake()
    {
        _propSpriteRenderer = GetComponent<SpriteRenderer>();
        _propRb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") && _propRb.velocity.sqrMagnitude > 0 && _propSpriteRenderer.color == _brushController.BluePaint)
        {
            _cineMachineShake.ShakeCamera(_cameraShakeIntensity, _cameraShakeFrequency, _cameraShakeTime);
            _propAudioSource.PlayOneShot(_stumpAudioClip);
        }
    }
}
