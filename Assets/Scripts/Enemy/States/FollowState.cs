using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public FollowState(EnemyController controller) : base(controller)
    {
        // Transicion Follow -> Idle
        Transition transitionFollowToIdle = new Transition(
            isValid: () => {
                float distance = Vector3.Distance(
                    controller.Player.position,
                    controller.transform.position
                );
                if (distance >= controller.DistanceToFollow)
                {
                    return true;
                }else
                {
                    return false;    
                }
            },
            getNextState: () => {
                return new IdleState(controller);
            }
        );
        Transitions.Add(transitionFollowToIdle);
    }


    public override void OnStart()
    {
        Debug.Log("Estado Follow: Start");
    }

    public override void OnUpdate()
    {
        //Debug.Log("Estado Follow: Update");
        Vector3 dir = (
            controller.Player.position - controller.transform.position
        ).normalized;
        controller.rb.velocity = dir * controller.Speed;

    }
    public override void OnFinish()
    {
        Debug.Log("Estado Follow: FInish");
    }
}
