using UnityEngine.UI;

public interface ICooldownable
{
    float Cooldown { get; }
    void SetImage(Image image);
    void UpdateImage(Image image);
}
