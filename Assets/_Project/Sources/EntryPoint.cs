using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private void Start()
    {
        AbilitiesBuilder.Instance.BuildGunShoot();
    }
}