using UnityEngine;

public class SpriteColorComponent : MonoBehaviour
{
    public Color BaseColor;

    public float MaxHue = 1.0f;
    public float MinHue = 0.0f;

    SpriteRenderer spriteRenderer;

    float h, s, v;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = BaseColor;
        Color.RGBToHSV(BaseColor, out h, out s, out v);
    }

    private void OnValidate()
    {
        ChangeColor();
    }

    private void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        float currentHue = Mathf.Clamp(Mathf.Repeat(h + ScenePalleteController.ShiftHue, 1.0f), MinHue, MaxHue);
        if (spriteRenderer != null)
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.HSVToRGB(currentHue, s, v), Time.deltaTime);
    }
}
