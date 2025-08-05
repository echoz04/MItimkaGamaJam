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

    void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.HSVToRGB(h + ScenePalleteController.ShiftHue, s, v), Time.deltaTime);
    }
}
