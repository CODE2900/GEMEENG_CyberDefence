using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class EnemyAIStateMachine : StateMachineBehaviour
{
    public GameObject unit;
    public GameObject target;
    public float unitBaseAttackTime;
    public float attackTime;
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        unit = animator.gameObject.transform.parent.transform.parent.gameObject;
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = unit.GetComponent<Targeting>().Target;
        if (target)
        {
            animator.SetBool("hasTarget", true);
            animator.SetBool("isPatrolling", false);
            if (IsTargetInRange())
            {
                animator.SetBool("isChasing", false);
                animator.SetBool("isAttacking", true);
            }
            else if (!IsTargetInRange())
            {
                animator.SetBool("isAttacking", false);
                animator.SetBool("isChasing", true);
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("hasTarget", false);
            animator.SetBool("isChasing", false);
            animator.SetBool("isPatrolling", true);
        }
        //if (unit.GetComponent<AIMovement>().IsLastWaypoint())
        //{
        //    animator.SetBool("isPatrolling", false);
        //    animator.SetBool("isIdle", true);
        //}
       
        //else if (unit.GetComponent<Enemy>().Target)
        //{
        //    if (unit.GetComponent<Animator>().GetBool("hasTarget") == false)
        //    {
        //        unit.GetComponent<Animator>().SetBool("hasTarget", true);
        //    }
        //}
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    bool IsTargetInRange()
    {
        //float distanceToTarget = Vector3.Distance(unit.transform.position, target.transform.position);
        ////Debug.Log("Distance to Target: " + distanceToTarget);
        //return distanceToTarget <= unit.GetComponent<Unit>().AttackRange;
        NavMeshAgent UnitNavMesh = unit.GetComponent<NavMeshAgent>();
        Assert.IsNotNull(UnitNavMesh);
        //Debug.Log("Distance to Target: " + UnitNavMesh.remainingDistance);
        return UnitNavMesh.remainingDistance <= UnitNavMesh.stoppingDistance;
    }
   
}
