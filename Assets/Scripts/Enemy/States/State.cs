using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected EnemyController controller;
    public List<Transition> Transitions;

    public State(EnemyController controller)
    {
        this.controller = controller;
        Transitions = new List<Transition>();
    }

    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract void OnFinish();

}
