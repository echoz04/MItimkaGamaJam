using UnityEngine;
using System.Collections.Generic;

public class GameStateMachine : StateMachine
{
    public override void Start()
    {
        base.Start();

        ChangeState(States["Tutorial"], StateMachine.empty_dict);
    }
}
