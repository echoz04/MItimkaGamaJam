using UnityEngine;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour
{

    private State state;
    public Dictionary<string, State> States;

    public static Dictionary<string, object> empty_dict = new Dictionary<string, object>(){};

    public virtual void Start()
    {
        States = new Dictionary<string, State>(){};
        foreach (var state in GetComponentsInChildren<State>())
        {
            States.Add(state.name, state);
        }
    }

    void Update()
    {
        if (state != null)
        {
            state.StateUpdate();
        }
    }

    
    void FixedUpdate()
    {
        if (state != null)
        {
            state.StateFixedUpdate();
        }
    }

    public void ChangeState(State new_state, Dictionary<string, object> props)
    {
        if (state != null)
        {
            state.StateExit();
        }

        props["StateMachine"] = this;
        new_state.StateEnter(props);
        state = new_state;
    }
}
