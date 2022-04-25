using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : StateMachineBehaviour
{
    public GameObject Unit;
    public float AttackTimer;
    public float AttackTime = 5; // Temporary for BAT 
    public Targeting UnitTargeting;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Unit = animator.transform.parent.gameObject.GetComponent<ModelInfo>().Parent; ;
        UnitTargeting = Unit.GetComponent<Targeting>();
        NavMeshAgent UnitAgent = Unit.GetComponent<NavMeshAgent>();
        if (UnitAgent)
        {
            if (!UnitAgent.isStopped)
            {
                UnitAgent.isStopped = true;
            }
           
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (UnitTargeting.Target)
        {
            Vector3 LookTransform = UnitTargeting.Target.transform.position;
            LookTransform.x = Unit.transform.position.x;

            Unit.transform.LookAt(LookTransform);


            if (AttackTimer >= AttackTime)
            {

                Unit.GetComponent<Enemy>().ShootTarget();
                AttackTimer = 0;
            }
            else
            {
                AttackTimer += Time.deltaTime;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
