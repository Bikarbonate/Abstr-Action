using UnityEngine;
using Cinemachine;

public class CineMachineShake : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cinemachineVirtualCamera;

    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;
    private float _shakeTimer;

    private void Awake()
    {
        _cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if(_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;
            
            if(_shakeTimer <= 0)
            {                
                _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
                _cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0;
            }
        }
    }

    public void ShakeCamera(float intensity, float frequency, float time)
    {
        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        _cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frequency;
        _shakeTimer = time;
    }
}
