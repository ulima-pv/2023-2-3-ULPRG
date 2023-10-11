using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(EnemyController controller) : base(controller)
    {
    }


    public override void OnStart()
    {
        Debug.Log("Estado Attack: Start");
        controller.Fire();
    }

    public override void OnUpdate()
    {
        
    }
    public override void OnFinish()
    {
        Debug.Log("Estado Attack: Finish");
    }
}
