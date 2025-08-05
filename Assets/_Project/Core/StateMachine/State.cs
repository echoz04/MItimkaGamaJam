using UnityEngine;
using System.Collections.Generic;

public class State : MonoBehaviour
{
    internal StateMachine stateMachine;

    public virtual void StateEnter(Dictionary<string, object> props)
    {
        stateMachine = (StateMachine)props["StateMachine"];
    }

    // Update is called once per frame when state is current
    public virtual void StateUpdate()
    {
        
    }

    // Update is called once per physics frame when state is current
    public virtual void StateFixedUpdate()
    {
        
    }

    public virtual void StateExit()
    {

    }

    public void ChangeState(State new_state, Dictionary<string, object> props)
    {
        stateMachine.ChangeState(new_state, props);
    }
}
