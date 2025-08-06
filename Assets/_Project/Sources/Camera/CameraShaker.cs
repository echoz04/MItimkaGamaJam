using Cinemachine;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker Instance { get; private set; }

    [SerializeField] private CinemachineImpulseSource _cinemachineImpulseSource;

    private void Awake()
    {
        Instance = this;
    }

    public void DoShake()
    {
        _cinemachineImpulseSource.GenerateImpulse();
    }
}
