using UnityEngine;

public class Item : MonoBehaviour
{
    public float PickUpDistance = 50.0f;

    public Transform PickUpperTransform;
    private Transform selfTransform;

    const float applyDistanceThreshold = 0.5f;

    void Start() {
        // TODO
        // PickUpperTransform = Player.instance.GetComponent<Transform>();
        selfTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        float distanceToPickUpper = Vector2.Distance(PickUpperTransform.position, selfTransform.position);
        if (distanceToPickUpper <= PickUpDistance)
        {
            selfTransform.position = Vector2.Lerp(selfTransform.position, PickUpperTransform.position, Time.deltaTime);

            if (distanceToPickUpper < applyDistanceThreshold)
            {
                Apply();
            }
        }
    }

    public virtual void Apply()
    {
        Destroy(this);
    }
}
