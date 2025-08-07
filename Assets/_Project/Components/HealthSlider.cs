using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public HealthComponent healthComponent;
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        healthComponent.OnHealthChanged += (delta) =>
        {
            UpdateSlider();
        };
        UpdateSlider();
    }

    // Update is called once per frame
    public void UpdateSlider()
    {
        slider.maxValue = healthComponent.MaxHealth;
        slider.value = healthComponent.Health;

        slider.gameObject.SetActive(slider.value != healthComponent.MaxHealth);

        //slider.value = healthComponent.Health / healthComponent.MaxHealth;
        //slider.gameObject.SetActive(slider.value != 1.0f);
    }
}
