using UnityEngine;
using System.Collections.Generic;

public class ScenePalleteController : MonoBehaviour
{
    public static Color ShiftColor;
    public static float ShiftHue;
    public List<Color> pallete = new List<Color>(){
        new Color(1.0f, 1.0f, 1.0f),  // WHITE
        new Color(1.0f, 0.76f, 0.71f),  // Peach
        new Color(0.94f, 0.38f, 0.36f), // Red
        new Color(0.29f, 0.21f, 0.51f), // Dark blue
        new Color(0.0f, 0.63f, 0.62f),  // Cyan
        new Color(1.0f, 0.83f, 0.38f),  // Yellow
        new Color(0.55f, 0.85f, 0.29f)  // Green
    };
    float hueShiftValue = 0.15f;

    int pallete_cursor = 0;

    float changeColorTimeLeft = 0.0f;
    float changeColorRate = 1.0f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        changeColorTimeLeft -= Time.deltaTime;
        if (changeColorTimeLeft <= 0)
        {
            changeColorTimeLeft = changeColorRate;

            NextColor();
        }
    }

    public void NextColor()
    {
        ShiftColor = pallete[pallete_cursor];
        pallete_cursor = (pallete_cursor + 1) % pallete.Count;
        ShiftHue += hueShiftValue;
    }
}
