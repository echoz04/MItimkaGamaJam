using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lifeTime;

    private void Start()
    {
        Invoke(nameof(Kill), _lifeTime);
        GetComponent<HurtBoxComponent>().OnHurted += (collider) =>
        {
            Kill();
            Debug.Log("Killed");
        };
    }

    private void Update()
    {
        transform.position += -transform.right * _moveSpeed * Time.deltaTime;
    }

    private void Kill() =>
        Destroy(gameObject);
}
