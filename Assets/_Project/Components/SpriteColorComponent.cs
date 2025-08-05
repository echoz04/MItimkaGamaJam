using UnityEngine;

public class SpriteColorComponent : MonoBehaviour
{
    public Color BaseColor;
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
        if (spriteRenderer != null)
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.HSVToRGB(Mathf.Repeat(h + ScenePalleteController.ShiftHue, 1.0f), s, v), Time.deltaTime);
    }
}
