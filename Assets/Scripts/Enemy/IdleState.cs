using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(EnemyController controller) : base(controller)
    {
    }

    public override void OnStart()
    {
        Debug.Log("Estado Idle Start");
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnFinish()
    {
        Debug.Log("Estado Idle Finish");
    }
}