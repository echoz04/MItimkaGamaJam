using UnityEngine;
using System.Collections.Generic;

public class Waves : State
{
    public override void StateEnter(Dictionary<string, object> props)
    {
        base.StateEnter(props);
        Debug.Log("Waves started!");
    }

    public override void StateFixedUpdate()
    {

    }
}
