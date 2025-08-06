using UnityEngine;
using System.Collections.Generic;

public class Tutorial : State
{
    [SerializeField] private GameObject _tutorialCanvas;
    [SerializeField] private GameObject _movementTooltip;

    float moving_goal_time_left = 0.0f;

    public static bool IsTutorialCompleted = false;

    public override void StateEnter(Dictionary<string, object> props)
    {
        base.StateEnter(props);

        _tutorialCanvas.SetActive(true);
        _movementTooltip.SetActive(true);

        moving_goal_time_left = 5.0f;
        Debug.Log("Tutorial started!");

        if (IsTutorialCompleted)
        {
            ChangeState(stateMachine.States["Waves"], StateMachine.empty_dict);
        }
    }

    public override void StateFixedUpdate()
    {
        if (moving_goal_time_left > 0.0f)
        {
            // TODO track that player moving
            bool isPlayerMoving = true;//(TankRoot)(TankRoot.Instance);

            if (TankRoot.Instance.IsMoving == true)
            {
                Debug.Log("Is Moving");

                moving_goal_time_left -= Time.deltaTime;
                // TODO update something in gui
            }
        }
        else if (false)
        {

        }

        else
        {
            ChangeState(stateMachine.States["Waves"], StateMachine.empty_dict);
        }
    }

    public override void StateExit()
    {
        _tutorialCanvas.SetActive(false);
        IsTutorialCompleted = true;

        Debug.Log("Tutorial completed!");
    }
}
