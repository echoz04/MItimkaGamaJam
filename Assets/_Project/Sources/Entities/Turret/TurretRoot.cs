using UnityEngine;

public class TurretRoot : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private void Start()
    {
        Invoke(nameof(Kill), _lifeTime);
    }

    private void Kill() =>
        Destroy(gameObject);
}
