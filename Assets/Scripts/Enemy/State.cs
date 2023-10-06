using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected EnemyController controller;

    public State(EnemyController controller)
    {
        this.controller = controller;
    }

    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract void OnFinish();

}
