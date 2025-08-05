using UnityEngine;
using System.Collections.Generic;

public class Tutorial : State
{
    float moving_goal_time_left = 0.0f;

    public override void StateEnter(Dictionary<string, object> props)
    {
        base.StateEnter(props);

        moving_goal_time_left = 5.0f;
        Debug.Log("Tutorial started!");
    }

    public override void StateFixedUpdate()
    {
        if (moving_goal_time_left >= 0.0f)
        {
            // TODO track that player moving
            bool isPlayerMoving = true;

            if (isPlayerMoving)
            {
                moving_goal_time_left -= Time.deltaTime;
                // TODO update something in gui
            }
        }
        else if (false)
        {

        }

        else {
            ChangeState(stateMachine.States["Waves"], StateMachine.empty_dict);
        }
    }

    public override void StateExit()
    {
        Debug.Log("Tutorial completed!");
    }
}
