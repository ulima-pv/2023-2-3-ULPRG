using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public FollowState(EnemyController controller) : base(controller)
    {
    }


    public override void OnStart()
    {
        Debug.Log("Estado Follow Start");
    }

    public override void OnUpdate()
    {
        
    }
    public override void OnFinish()
    {
        Debug.Log("Estado Follow Start");
    }
}
